namespace GWB.Example.Web.Api.gRPC.ErrorHandling;

using Application.Core.Results;
using Grpc.Core;

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
            throw new RpcException(new Status(StatusCode.Unknown, failure.Error.Message));
        }

        throw new RpcException(new Status(StatusCode.Unknown, "Unknown Query Result"));
    }
}