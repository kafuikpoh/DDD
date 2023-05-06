using DDD.Application.Common.Interfaces.Persistence;
using DDD.Domain.MenuAggregate;

namespace DDD.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);

        _dbContext.SaveChanges();
    }
}