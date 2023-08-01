using DDD.Domain.GuestAggregate;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Persistence.Configurations;

public class GuestConfigurations : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => GuestId.Create(value));

        builder.Property(g => g.FirstName)
            .HasMaxLength(100);

        builder.Property(g => g.LastName)
            .HasMaxLength(100);

        builder.Property(g => g.UserId)
            .HasConversion(id => id.Value, value => UserId.Create(value));
    }
}
