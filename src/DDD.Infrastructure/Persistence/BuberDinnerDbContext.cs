using DDD.Domain.BillAggregate;
using DDD.Domain.Common.Models;
using DDD.Domain.DinnerAggregate;
using DDD.Domain.GuestAggregate;
using DDD.Domain.Host;
using DDD.Domain.MenuAggregate;
using DDD.Domain.MenuReviewAggregate;
using DDD.Domain.UserAggregate;
using DDD.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Persistence;

public class BuberDinnerDbContext : DbContext
{
    private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor;
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options, PublishDomainEventInterceptor publishDomainEventInterceptor)
        : base(options)
    {
        _publishDomainEventInterceptor = publishDomainEventInterceptor;
    }

    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<Dinner> Dinners { get; set; } = null!;
    public DbSet<Guest> Guests { get; set; } = null!;
    public DbSet<Host> Hosts { get; set; } = null!;
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<MenuReview> MenuReviews { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<List<IDomainEvent>>().ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}