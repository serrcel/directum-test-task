using Directum.Backend.Core.Entities;

namespace Directum.Backend.Core.Interfaces;

public interface IPostRepository
{
    Task<Post?> GetByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetAllAsync();
    Task AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Guid id);
}