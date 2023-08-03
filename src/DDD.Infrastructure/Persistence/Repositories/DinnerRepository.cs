using DDD.Application.Common.Interfaces.Persistence;
using DDD.Domain.DinnerAggregate;
using DDD.Domain.HostAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Persistence.Repositories;

public class DinnerRepository : IDinnerRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public DinnerRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Dinner dinner)
    {
        await _dbContext.AddAsync(dinner);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Dinner>> ListAsync(HostId hostId)
    {
        return await _dbContext.Dinners.Where(dinner => dinner.HostId == hostId).ToListAsync();
    }
}
