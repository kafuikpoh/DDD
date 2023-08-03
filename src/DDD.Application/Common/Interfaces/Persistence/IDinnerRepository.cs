using DDD.Domain.DinnerAggregate;
using DDD.Domain.HostAggregate.ValueObjects;

namespace DDD.Application.Common.Interfaces.Persistence;

public interface IDinnerRepository
{
    Task AddAsync(Dinner dinner);
    Task<List<Dinner>> ListAsync(HostId hostId);
}