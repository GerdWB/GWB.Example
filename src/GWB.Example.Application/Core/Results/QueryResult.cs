namespace GWB.Example.Application.Core.Results;

public abstract record QueryResult<T>(bool IsSuccess)
{
    public static implicit operator QueryResult<T>(Exception exception) => new QueryFailed<T>(exception.Message);

    public static implicit operator QueryResult<T>(T value) =>
        value is not null
            ? new QuerySuccess<T>(value)
            : new QueryFailed<T>("Result of query is null");

    public bool IsFailure => !IsSuccess;
}

public record QueryFailed<T>(string Reason) : QueryResult<T>(false);

public record QuerySuccess<T>(T Value) : QueryResult<T>(true)
{
    public static implicit operator T(QuerySuccess<T> success) => success.Value;

    public static implicit operator QuerySuccess<T>(T value) =>
        value is not null
            ? new QuerySuccess<T>(value)
            : throw new ArgumentNullException(nameof(value));

    public T Value { get; init; } = Value ?? throw new ArgumentNullException(nameof(Value));
}