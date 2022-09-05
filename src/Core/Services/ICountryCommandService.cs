namespace GWB.Example.Application.Core.Services;

public interface ICountryCommandService
{
    Task<CommandResult> CreateAsync(IEnumerable<Country> countries);

    Task<CommandResult> DeleteAsync(IEnumerable<Country> countries);

    Task<CommandResult> UpdateAsync(Country country);
}