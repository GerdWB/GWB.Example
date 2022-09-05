namespace GWB.Example.Web.Blazor.Services;

using Application.Core.Domain.Entities;
using Application.Core.Results;
using Google.Protobuf.WellKnownTypes;
using gRPC;
using Grpc.Net.Client;
using ProtoBuf.Mappings;

public class CountryService
{
    private readonly GrpcChannel grpcChannel;

    public CountryService(GrpcChannel grpcChannel)
        => this.grpcChannel = grpcChannel;

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        var client = new CountryGrpcService.CountryGrpcServiceClient(grpcChannel);
        var response = await client.GetAllAsync(new Empty());

        return response.FromProto();
    }

    public Task<QueryResult<Country>> GetByIdAsync(Guid requestCountryId) => throw new NotImplementedException();
}