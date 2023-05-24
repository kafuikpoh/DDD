using System;
using System.Text;
using DDD.Application.Common.Interfaces.Authentication;
using DDD.Application.Common.Interfaces.Persistence;
using DDD.Application.Common.Interfaces.Services;
using DDD.Infrastructure.Authentication;
using DDD.Infrastructure.Persistence;
using DDD.Infrastructure.Persistence.Interceptors;
using DDD.Infrastructure.Persistence.Repositories;
using DDD.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DDD.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration).AddPersistence(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<PublishDomainEventInterceptor>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddDbContext<BuberDinnerDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }
}