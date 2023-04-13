using DDD.Application.Common.Interfaces.Persistence;
using DDD.Domain.MenuAggregate;

namespace DDD.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}