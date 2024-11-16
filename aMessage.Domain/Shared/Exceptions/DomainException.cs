using System.Net;

namespace aMessage.Domain.Shared.Exceptions;

public class DomainException : ArgumentException
{
    public HttpStatusCode Reason { get; init; }

    internal DomainException(DomainError error) : base(error.ErrorMessage)
    {
        Reason = error.Reason;
    }
}
