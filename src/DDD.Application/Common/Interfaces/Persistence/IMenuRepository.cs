using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate;
using DDD.Domain.MenuAggregate.ValueObjects;

namespace DDD.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task AddAsync(Menu menu);
    Task UpdateAsync(Menu menu);
    Task<Menu?> GetByIdAsync(MenuId menuId);
    Task<bool> ExistsAsync(MenuId menuId);
    Task<List<Menu>> ListAsync(HostId hostId);
}