namespace GWB.Example.Web.Blazor.Services;

using Application.Core.Domain.Entities;
using Application.Core.Results;
using Google.Protobuf.WellKnownTypes;
using gRPC;
using ProtoBuf.Mappings;

public class CountryService
{
    private readonly CountryGrpcService.CountryGrpcServiceClient _countryGrpcService;

    public CountryService(CountryGrpcService.CountryGrpcServiceClient client)
        => _countryGrpcService = client ?? throw new ArgumentNullException(nameof(client));

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        var response = await _countryGrpcService.GetAllAsync(new Empty());
        return response.FromProto();
    }

    public Task<QueryResult<Country>> GetByIdAsync(Guid requestCountryId) => throw new NotImplementedException();
}