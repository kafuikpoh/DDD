using System;
using DDD.Domain.Entities;

namespace DDD.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}

