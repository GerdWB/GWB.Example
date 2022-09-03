namespace Web.Api.gRPC.Server.Integration.Tests;

using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GWB.Example.gRPC;
using TestSetup;

public class CountryServiceIntegrationTests : IClassFixture<CountryServiceTestFixture>
{
    private readonly GrpcChannel _channel;

    public CountryServiceIntegrationTests(CountryServiceTestFixture factory) => _channel = factory.Channel;

    [Fact]
    public async Task SayHelloUnaryTest()
    {
        // Arrange
        var client = new CountryService.CountryServiceClient(_channel);

        // Act
        var response = await client.GetAllAsync(new Empty());

        // Assert
        Assert.NotNull(response);
    }
}