using System;
using DDD.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DDD.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;

