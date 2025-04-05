using Directum.Backend.Core.Entities;
using Directum.Backend.Core.Interfaces;
using Directum.Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Directum.Backend.Infrastructure.Repositories;

public class PostRepository: IPostRepository
{
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Post?> GetByIdAsync(Guid id) =>
        await _context.Posts.FindAsync(id);

    public async Task<IEnumerable<Post>> GetAllAsync() =>
        await _context.Posts.ToListAsync();

    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Post post)
    {
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}