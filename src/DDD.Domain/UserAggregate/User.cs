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

    private User(
        string firstName,
        string lastName,
        string email,
        string password,
        UserId? userId = null) : base(userId ?? UserId.CreateUnique())
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
        //TODO: enforce invariance
        return new(
            firstName,
            lastName,
            email,
            password);
    }
#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
}