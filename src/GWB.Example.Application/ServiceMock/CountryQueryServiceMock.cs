namespace GWB.Example.ServiceMock;

using Application.Core.Domain.Entities;
using Application.Core.Results;
using Application.Core.Services;

public class CountryQueryServiceMock : ICountryQueryService
{
    public Task<QueryResult<IEnumerable<Country>>> GetAllAsync() => throw new NotImplementedException();

    public Task<QueryResult<Country>> GetByIdAsync(Guid requestCountryId) => throw new NotImplementedException();
}