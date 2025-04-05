using Directum.Backend.Core.Entities;
using Directum.Backend.Core.Interfaces;
using Directum.Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Directum.Backend.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment?> GetByIdAsync(Guid id) =>
        await _context.Comments.FindAsync(id);

    public async Task<IEnumerable<Comment>> GetAllAsync() =>
        await _context.Comments.ToListAsync();

    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Comment comment)
    {
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}