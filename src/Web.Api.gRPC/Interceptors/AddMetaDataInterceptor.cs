namespace GWB.Example.Web.Api.gRPC.Interceptors;

using System.Diagnostics;
using Grpc.Core;
using Grpc.Core.Interceptors;

public class AddMetaDataInterceptor : Interceptor
{
    public const string CorrelationIdString = "CorrelationId";
    public const string DurationString = "Duration";

    private static Metadata.Entry CreateTimingMetadata(Stopwatch sw)
        => new(DurationString, sw.Elapsed.TotalMilliseconds.ToString("#0.000 ms"));

    private static Metadata.Entry CreateTrailers(Guid correlationId)
        => new(CorrelationIdString, correlationId.ToString());

    private readonly Metadata.Entry _correlationMetaData;

    public AddMetaDataInterceptor() => _correlationMetaData = CreateTrailers(Guid.NewGuid());

    public override async Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(
        IAsyncStreamReader<TRequest> requestStream,
        ServerCallContext context,
        ClientStreamingServerMethod<TRequest, TResponse> continuation)
    {
        context.ResponseTrailers.Add(_correlationMetaData);
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
        if (context.ResponseTrailers.All(x => x.Key != CorrelationIdString))
        {
            context.ResponseTrailers.Add(_correlationMetaData);
        }

        await continuation(requestStream, responseStream, context);
    }


    public override async Task ServerStreamingServerHandler<TRequest, TResponse>(
        TRequest request,
        IServerStreamWriter<TResponse> responseStream,
        ServerCallContext context,
        ServerStreamingServerMethod<TRequest, TResponse> continuation)
    {
        if (context.ResponseTrailers.All(x => x.Key != CorrelationIdString))
        {
            context.ResponseTrailers.Add(_correlationMetaData);
        }

        await continuation(request, responseStream, context);
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        var sw = Stopwatch.StartNew();
        if (context.ResponseTrailers.All(x => x.Key != CorrelationIdString))
        {
            context.ResponseTrailers.Add(_correlationMetaData);
        }

        var continuator = await continuation(request, context);
        context.ResponseTrailers.Add(CreateTimingMetadata(sw));
        return continuator;
    }
}