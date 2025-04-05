using Directum.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Directum.Backend.Infrastructure.Data.Configurations;

public class PostConfiguration: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Author).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Content).IsRequired();
        builder.Property(p => p.Preview).HasMaxLength(255);
    }
}