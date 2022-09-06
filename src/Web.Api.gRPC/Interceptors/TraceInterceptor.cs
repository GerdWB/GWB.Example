namespace GWB.Example.Web.Api.gRPC.Interceptors;

using Grpc.Core;
using Grpc.Core.Interceptors;

public class TraceInterceptor : Interceptor
{
    private readonly ILogger<TraceInterceptor> _logger;


    public TraceInterceptor(ILogger<TraceInterceptor> logger) => _logger = logger;

    public override async Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(
        IAsyncStreamReader<TRequest> requestStream,
        ServerCallContext context,
        ClientStreamingServerMethod<TRequest, TResponse> continuation)
    {
        LogBeforeEnter(context);
        var continuator = await continuation(requestStream, context);
        LogAfterLeaf(context);
        return continuator;
    }

    public override async Task DuplexStreamingServerHandler<TRequest, TResponse>(
        IAsyncStreamReader<TRequest> requestStream,
        IServerStreamWriter<TResponse> responseStream,
        ServerCallContext context,
        DuplexStreamingServerMethod<TRequest, TResponse> continuation)
    {
        LogBeforeEnter(context);
        await continuation(requestStream, responseStream, context);
        LogAfterLeaf(context);
    }


    public override async Task ServerStreamingServerHandler<TRequest, TResponse>(
        TRequest request,
        IServerStreamWriter<TResponse> responseStream,
        ServerCallContext context,
        ServerStreamingServerMethod<TRequest, TResponse> continuation)
    {
        LogBeforeEnter(context);
        await continuation(request, responseStream, context);
        LogAfterLeaf(context);
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        LogBeforeEnter(context);
        var continuator = await continuation(request, context);
        LogAfterLeaf(context);
        return continuator;
    }

    private void LogAfterLeaf(ServerCallContext context)
    {
        _logger.LogTrace("Before enter {Method} {CorrelationId}", context.Method, context.CorrelationId());
    }

    private void LogBeforeEnter(ServerCallContext context)
    {
        _logger.LogTrace("Before enter {Method} {CorrelationId}", context.Method, context.CorrelationId());
    }
}