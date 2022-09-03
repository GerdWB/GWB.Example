namespace Web.Api.gRPC.Server.Functional.Tests;

using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GWB.Example.gRPC;
using TestSetup;

public class CountryServiceIntegrationTests : IClassFixture<CountryServiceTestFixture>
{
    private readonly GrpcChannel _channel;

    public CountryServiceIntegrationTests(CountryServiceTestFixture factory) => _channel = factory.Channel;

    [Fact]
    public void GetAll_Should_Return_A_CountryListReply()
    {
        // Arrange
        var client = new CountryService.CountryServiceClient(_channel);

        // Act
        var response = client.GetAll(new Empty());

        // Assert
        response.Should().NotBeNull();
        response.Should().BeOfType<CountryListReply>();
        response.As<CountryListReply>().Countries.Count.Should().BeGreaterThan(2);
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_A_CountryListReply()
    {
        // Arrange
        var client = new CountryService.CountryServiceClient(_channel);

        // Act
        var response = await client.GetAllAsync(new Empty());

        // Assert
        response.Should().NotBeNull();
        response.Should().BeOfType<CountryListReply>();
        response.As<CountryListReply>().Countries.Count.Should().BeGreaterThan(2);
    }
}