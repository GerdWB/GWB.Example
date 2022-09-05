namespace GWB.Example.Application.Core.Services;

public interface ICountryQueryService
{
    Task<QueryResult<IEnumerable<Country>>> GetAllAsync();

    Task<QueryResult<Country>> GetByIdAsync(Guid requestCountryId);
}