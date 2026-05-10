using ProfileService.Domain.Exceptions;

namespace ProfileService.Domain.Exceptions.Custom;

public sealed class ConflictDomainException : DomainExceptionBase
{
    public ConflictDomainException(string message) : base(message) { }

    public ConflictDomainException(string message, Exception? innerException) : base(message, innerException) { }
}

