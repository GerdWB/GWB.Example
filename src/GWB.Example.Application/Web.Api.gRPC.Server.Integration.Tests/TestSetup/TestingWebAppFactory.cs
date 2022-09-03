namespace Web.Api.gRPC.Server.Integration.Tests.TestSetup;

using global::Tests.Server.IntegrationTests.Helpers;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public abstract class TestingWebAppFactory : WebApplicationFactory<Program>
{
    public delegate void LogMessage(
        LogLevel logLevel,
        string categoryName,
        EventId eventId,
        string message,
        Exception? exception);

    private GrpcChannel? _channel;

    public GrpcChannel Channel => _channel ??= CreateChannel();

    public event LogMessage? LoggedMessage;

    public ILoggerFactory? LoggerFactory;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            ReConfigureServices(services);
            var sp = services.BuildServiceProvider();
        });

        LoggerFactory = new LoggerFactory();
        LoggerFactory.AddProvider(new ForwardingLoggerProvider((logLevel, category, eventId, message, exception) =>
        {
            LoggedMessage?.Invoke(logLevel, category, eventId, message, exception);
        }));
    }

    protected virtual void ReConfigureServices(IServiceCollection services)
    {
    }

    private GrpcChannel CreateChannel()
    {
        var client = CreateDefaultClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
        return GrpcChannel.ForAddress("https://localhost:7106",
            new GrpcChannelOptions
            {
                HttpClient = client,
                LoggerFactory = LoggerFactory
            });
    }
}