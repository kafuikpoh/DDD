using System;
using DDD.Domain.UserAggregate;

namespace DDD.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
