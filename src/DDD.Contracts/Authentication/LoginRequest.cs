using System;
namespace DDD.Contracts.Authentication;

public record LoginRequest(string Email, string Password);
