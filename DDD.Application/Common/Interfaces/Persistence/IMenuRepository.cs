using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate;
using DDD.Domain.MenuAggregate.ValueObjects;

namespace DDD.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task Add(Menu menu);
    Task<IEnumerable<Menu>> Fetch(HostId hostId, MenuId menuId);
}