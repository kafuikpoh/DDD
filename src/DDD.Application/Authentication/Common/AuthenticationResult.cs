using System;
using DDD.Domain.Entities;

namespace DDD.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);

