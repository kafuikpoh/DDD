using System;
namespace DDD.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; init; } = default!;
    public int ExpirationTimeInMinutes { get; init; }
    public string Issuer { get; init; } = default!;
    public string Audience { get; init; } = default!;
}