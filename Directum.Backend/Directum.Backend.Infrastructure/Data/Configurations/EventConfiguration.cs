using Directum.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Directum.Backend.Infrastructure.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
        builder.Property(e => e.RequiredParticipants).IsRequired();
        builder.Property(e => e.EventDate).IsRequired();
    }
}