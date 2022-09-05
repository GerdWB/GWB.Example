namespace GWB.Example.Application.Core.Results;

public abstract record CommandResult(bool IsSuccess)
{
    public bool IsFailure => !IsSuccess;
}

public record CommandSucceeded() : CommandResult(true);

public record CommandFailed(Error Error) : CommandResult(false);