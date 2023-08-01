using DDD.Domain.BillAggregate.ValueObjects;
using DDD.Domain.DinnerAggregate;
using DDD.Domain.DinnerAggregate.Enums;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Persistence.Configurations;

public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigureDinnerReservationsTable(builder);
    }

    private static void ConfigureDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(d => d.Reservations, rb =>
        {
            rb.ToTable("DinnersReservations");

            rb.WithOwner().HasForeignKey("DinnerId");

            rb.HasKey("DinnerId", "Id");

            rb.Property(r => r.Id)
                .HasColumnName("ReservationId")
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ReservationId.Create(value));

            rb.Property(r => r.GuestId)
                .HasConversion(id => id.Value, value => GuestId.Create(value));

            rb.Property(r => r.BillId)
                .HasConversion(id => id!.Value, value => BillId.Create(value));

            rb.Property(r => r.ReservationStatus)
                .HasColumnName("Status")
                .HasConversion(status => status.Value, value => ReservationStatus.FromValue(value));
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => DinnerId.Create(value));

        builder.Property(d => d.Name)
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(100);

        builder.Property(d => d.Status)
            .HasConversion(
                status => status.Value,
                value => DinnerStatus.FromValue(value));

        builder.OwnsOne(d => d.Price, pb => pb.Property(p => p.Amount).HasColumnType("decimal(10,4)"));

        builder.Property(d => d.HostId)
            .HasConversion(id => id.Value, value => HostId.Create(value));

        builder.Property(d => d.MenuId)
            .HasConversion(id => id.Value, value => MenuId.Create(value));

        builder.OwnsOne(d => d.Location);
    }
}