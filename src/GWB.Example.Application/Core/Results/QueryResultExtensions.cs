namespace GWB.Example.Application.Core.Results;

public static class QueryResultExtensions
{
    public static QueryResult<T> OnFailure<T>(this QueryResult<T> queryResult, Action<QueryFailed<T>> onFailure)
    {
        switch (queryResult)
        {
            case QuerySuccess<T> _:
                return queryResult;
            case QueryFailed<T> failure:
                onFailure(failure);
                return queryResult;
            default:
                throw new Exception("unexpected result");
        }
    }

    public static QueryResult<T> OnSuccess<T>(this QueryResult<T> queryResult, Action<QuerySuccess<T>> onSuccess)
    {
        switch (queryResult)
        {
            case QuerySuccess<T> success:
                onSuccess(success);
                return queryResult;
            case QueryFailed<T> _:
                return queryResult;
            default:
                throw new Exception("unexpected result");
        }
    }
}