﻿using System;
using DDD.Application.Common.Interfaces.Persistence;
using DDD.Domain.UserAggregate;

namespace DDD.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public UserRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Email == email);
    }
}