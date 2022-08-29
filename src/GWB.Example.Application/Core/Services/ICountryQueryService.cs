namespace GWB.Example.Application.Core.Services;

using Domain;
using Results;

public interface ICountryQueryService
{
    Task<QueryResult<IEnumerable<Country>>> GetAllAsync();

    Task<QueryResult<Country>> GetByIdAsync(Guid requestCountryId);
}