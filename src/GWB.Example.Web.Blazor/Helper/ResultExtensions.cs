namespace GWB.Example.Web.Blazor.Helper;

using Application.Core.Results;

public static class ResultExtensions
{
    public static T HandleResult<T>(this QueryResult<T> result)
    {
        if (result is QuerySuccess<T> success)
        {
            return success.Value;
        }

        if (result is QueryFailed<T> failure)
        {
            throw new Exception(failure.Error.Message);
        }

        throw new Exception("Unknown");
    }
}