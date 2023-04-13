using System;
namespace DDD.Application.Common.Errors;

public class DuplicateEmailException : Exception
{
    public DuplicateEmailException()
    {
    }

    public DuplicateEmailException(string? message) : base(message)
    {
    }

    public DuplicateEmailException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
