using HC_7111.Domain.Objects;

namespace HC_7111.GraphQL;

[MutationType]
public class LibraryMutation
{
    [Error<DomainError>]
    public Library? LibraryCreate(string name)
    {
        throw new DomainException("bad");
    }
}

public class DomainException(string type) : Exception
{
    public string Type { get; } = type;
}

public record DomainError
{
    public string Message => "a domain exception was thrown...";

    public string Type { get; }

    public DomainError(string type)
    {
        Type = type;
    }

    public static DomainError? CreateErrorFrom(DomainException exception)
        => new DomainError(exception.Type);
}

[ObjectType<DomainError>]
public static partial class DomainErrorType
{
    static partial void Configure(IObjectTypeDescriptor<DomainError> descriptor)
    {
        descriptor
            .Field(p => p.Message);

        descriptor
            .Field(p => p.Type);
    }
}

[ObjectType<DomainException>]
public static partial class DomainExceptionType
{
    static partial void Configure(IObjectTypeDescriptor<DomainException> descriptor)
    {
        descriptor
            .Field(p => p.Message);

        descriptor
            .Field(p => p.Type);
    }
}