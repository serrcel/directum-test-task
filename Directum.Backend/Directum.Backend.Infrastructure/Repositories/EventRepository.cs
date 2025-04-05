using Directum.Backend.Core.Entities;
using Directum.Backend.Core.Interfaces;
using Directum.Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Directum.Backend.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly ApplicationDbContext _context;

    public EventRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Event?> GetByIdAsync(Guid id) =>
        await _context.Events.FindAsync(id);

    public async Task<IEnumerable<Event>> GetAllAsync() =>
        await _context.Events.ToListAsync();

    public async Task AddAsync(Event @event)
    {
        await _context.Events.AddAsync(@event);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Event @event)
    {
        _context.Events.Update(@event);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var @event = await _context.Events.FindAsync(id);
        if (@event != null)
        {
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
        }
    }
}