using DDD.Domain.Common.Models;
using DDD.Domain.UserAggregate.ValueObjects;

namespace DDD.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId, Guid>
{
    
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!; //hash this
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(UserId userId,
        string firstName,
        string lastName,
        string email,
        string password) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password);
    }
}