namespace GWB.Example.ServiceMock;

using Application.Core.Domain.Entities;
using Application.Core.Results;
using Application.Core.Services;

public class CountryCommandServiceMock : ICountryCommandService
{
    public Task<CommandResult> CreateAsync(IEnumerable<Country> countries) => throw new NotImplementedException();

    public Task<CommandResult> DeleteAsync(IEnumerable<Country> countries) => throw new NotImplementedException();

    public Task<CommandResult> UpdateAsync(Country country) => throw new NotImplementedException();
}