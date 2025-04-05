using Directum.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Directum.Backend.Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Post> Posts => this.Set<Post>();
    public DbSet<Comment> Comments => this.Set<Comment>();
    public DbSet<Event> Events => this.Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
