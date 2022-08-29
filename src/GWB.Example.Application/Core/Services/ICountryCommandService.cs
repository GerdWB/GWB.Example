namespace GWB.Example.Application.Core.Services;

using Domain.Entities;
using Results;

public interface ICountryCommandService
{
    Task<CommandResult> CreateAsync(IEnumerable<Country> countries);

    Task<CommandResult> DeleteAsync(IEnumerable<Country> countries);

    Task<CommandResult> UpdateAsync(Country country);
}