using Grpc.Core;
using GWB.Example.Application.Core.Results;

namespace GWB.Example.Web.Api.gRPC.ErrorHandling
{
    public static class ResultExtensions
    {
        public static T HandleResult<T>(this QueryResult<T> result)
        {
            if (result is QuerySuccess<T> success)
            {
                return success.Value;
            }
            else if (result is QueryFailed<T> failure)
            {
                throw new RpcException(new Status(StatusCode.Unknown, failure.Reason));
            }
            throw new RpcException(new Status(StatusCode.Unknown, "Unknown Query Result"));
        }
    }
}
