using DDD.Domain.Common.Models;
using DDD.Domain.MenuAggregate;
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

    public DbSet<Menu> Menus { get; set; }

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