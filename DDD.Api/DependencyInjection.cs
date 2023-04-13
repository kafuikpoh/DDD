using System;
using DDD.Api.Common.Errors;
using DDD.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DDD.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DddProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}