namespace GWB.Example.ServiceMock;

using System.Collections.Concurrent;
using Application.Core.Domain;

internal static class CountryData
{
    public static IReadOnlyList<Country> Countries => _countries.Values.ToList().AsReadOnly();

    private static readonly ConcurrentDictionary<Guid, Country>
        _countries = new(); // C# 9 syntax "Improved target typing"

    static CountryData()
    {
        Add(new Country(
            Guid.NewGuid(),
            "Canada", "Canada has at least 32 000 lakes",
            null, DateTime.SpecifyKind(new DateTime(2021, 1, 2), DateTimeKind.Utc), null));

        Add(new Country(
            Guid.NewGuid(),
            "Mexico", "Mexico is crossed by Sierra Madre Oriental and Sierra Madre Occidental mountains",
            null, DateTime.SpecifyKind(new DateTime(2021, 1, 2), DateTimeKind.Utc), null));

        Add(new Country(
            Guid.NewGuid(),
            "USA", "Yellowstone has 300 to 500 geysers",
            null, DateTime.SpecifyKind(new DateTime(2021, 1, 2), DateTimeKind.Utc), null));
    }

    public static void Add(Country country)
    {
        _countries.AddOrUpdate(country.Id, country, updateValueFactory: (_, _) => country);
    }

    public static void Add(IEnumerable<Country> countries)
    {
        foreach (var country in countries)
        {
            _countries.AddOrUpdate(country.Id, country, updateValueFactory: (_, _) => country);
        }
    }

    public static void Remove(Country country)
    {
        _countries.TryRemove(country.Id, out _);
    }

    public static void Update(Country country)
    {
        _countries.AddOrUpdate(country.Id, country, updateValueFactory: (_, _) => country);
    }
}