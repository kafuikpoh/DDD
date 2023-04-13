using System;
using DDD.Application.Authentication.Commands.Register;
using DDD.Application.Authentication.Common;
using DDD.Application.Authentication.Queries.Login;
using DDD.Contracts.Authentication;
using Mapster;

namespace DDD.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}

