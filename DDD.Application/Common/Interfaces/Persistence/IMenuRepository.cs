using DDD.Domain.MenuAggregate;

namespace DDD.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    //void Add(Menu menu);
    Task Add(Menu menu);
}