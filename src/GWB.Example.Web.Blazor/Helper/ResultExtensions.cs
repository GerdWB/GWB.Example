namespace GWB.Example.Web.Blazor.Helper;

using Application.Core.Results;

public static class ResultExtensions
{
    public static T HandleResult<T>(this QueryResult<T> result)
    {
        return result switch
        {
            QuerySuccess<T> success => success.Value,
            QueryFailed<T> failure => throw new Exception(failure.Error.Message),
            _ => throw new Exception("Unknown")
        };
    }
}