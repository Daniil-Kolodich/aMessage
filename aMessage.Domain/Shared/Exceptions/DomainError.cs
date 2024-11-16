using System.Net;

namespace aMessage.Domain.Shared.Exceptions;

internal sealed record DomainError(string ErrorMessage, HttpStatusCode Reason)
{
    public static implicit operator DomainException(DomainError error) => new DomainException(error);
}