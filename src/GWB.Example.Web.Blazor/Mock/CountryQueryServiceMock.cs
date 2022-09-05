namespace GWB.Example.Web.Blazor.Mock;

using Application.Core.Domain.Entities;
using Application.Core.Results;
using Application.Core.Services;
using ServiceMock;

public class CountryQueryServiceMock : ICountryQueryService
{
    public Task<QueryResult<IEnumerable<Country>>> GetAllAsync()
        => Task.FromResult<QueryResult<IEnumerable<Country>>>(
            new QuerySuccess<IEnumerable<Country>>(CountryData.Countries));

    public Task<QueryResult<Country>> GetByIdAsync(Guid requestCountryId) => throw new NotImplementedException();
}