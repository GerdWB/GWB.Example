namespace GWB.Example.Web.Blazor.Pages;

using Application.Core.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Services;

public partial class Index
{
    private IEnumerable<Country> _countries = new List<Country>();

    private bool _hidePosition;
    private bool _loading;

#pragma warning disable CS8618
    [Inject] private CountryService CountryService { get; set; }
#pragma warning restore CS8618

    protected override async Task OnInitializedAsync()
    {
        _countries = await CountryService.GetAllAsync();
    }

    private async Task Reload()
    {
        _countries = await CountryService.GetAllAsync();
    }
}