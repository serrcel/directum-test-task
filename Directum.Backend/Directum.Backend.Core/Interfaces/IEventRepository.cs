using Directum.Backend.Core.Entities;

namespace Directum.Backend.Core.Interfaces;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(Guid id);
    Task<IEnumerable<Event>> GetAllAsync();
    Task AddAsync(Event @event);
    Task UpdateAsync(Event @event);
    Task DeleteAsync(Guid id);
}