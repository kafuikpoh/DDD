using System;
using DDD.Domain.UserAggregate;

namespace DDD.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);

