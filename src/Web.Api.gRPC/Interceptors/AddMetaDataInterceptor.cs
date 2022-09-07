namespace GWB.Example.Web.Api.gRPC.Interceptors;

using System.Diagnostics;
using Grpc.Core;
using Grpc.Core.Interceptors;

public class AddMetaDataInterceptor : Interceptor
{
    public const string DurationString = "Duration";

    private static Metadata.Entry CreateTimingMetadata(Stopwatch sw)
        => new(DurationString, sw.Elapsed.TotalMilliseconds.ToString("#0.000 ms"));


    public override async Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(
        IAsyncStreamReader<TRequest> requestStream,
        ServerCallContext context,
        ClientStreamingServerMethod<TRequest, TResponse> continuation)
    {
        var sw = Stopwatch.StartNew();
        var continuator = await continuation(requestStream, context);
        context.ResponseTrailers.Add(CreateTimingMetadata(sw));
        return continuator;
    }

    public override async Task DuplexStreamingServerHandler<TRequest, TResponse>(
        IAsyncStreamReader<TRequest> requestStream,
        IServerStreamWriter<TResponse> responseStream,
        ServerCallContext context,
        DuplexStreamingServerMethod<TRequest, TResponse> continuation)
    {
        var sw = Stopwatch.StartNew();
        await continuation(requestStream, responseStream, context);
        context.ResponseTrailers.Add(CreateTimingMetadata(sw));
    }


    public override async Task ServerStreamingServerHandler<TRequest, TResponse>(
        TRequest request,
        IServerStreamWriter<TResponse> responseStream,
        ServerCallContext context,
        ServerStreamingServerMethod<TRequest, TResponse> continuation)
    {
        var sw = Stopwatch.StartNew();
        await continuation(request, responseStream, context);
        context.ResponseTrailers.Add(CreateTimingMetadata(sw));
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        var sw = Stopwatch.StartNew();
        var continuator = await continuation(request, context);
        context.ResponseTrailers.Add(CreateTimingMetadata(sw));
        return continuator;
    }
}