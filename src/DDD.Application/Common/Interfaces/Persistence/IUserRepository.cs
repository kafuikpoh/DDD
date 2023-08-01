using System;
using DDD.Domain.UserAggregate;

namespace DDD.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}

