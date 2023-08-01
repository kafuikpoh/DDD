using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate.ValueObjects;
using DDD.Domain.MenuReviewAggregate;
using DDD.Domain.MenuReviewAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Persistence.Configurations;

public class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        builder.ToTable("MenuReviews");

        builder.HasKey(mr => mr.Id);

        builder.Property(mr => mr.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuReviewId.Create(value));

        builder.Property(mr => mr.Rating);

        builder.Property(mr => mr.Comment)
            .HasMaxLength(500);

        builder.Property(mr => mr.HostId)
            .HasConversion(id => id.Value, value => HostId.Create(value));

        builder.Property(mr => mr.MenuId)
            .HasConversion(id => id.Value, value => MenuId.Create(value));

        builder.Property(mr => mr.GuestId)
            .HasConversion(id => id.Value, value => GuestId.Create(value));

        builder.Property(mr => mr.DinnerId)
            .HasConversion(id => id.Value, value => DinnerId.Create(value));
    }
}
