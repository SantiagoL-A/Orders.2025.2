using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.shared.Entities;

namespace Orders.Frontend.Components.Pages.Countries;

public partial class CountriesIndex
{
    private List<Country>? countries;

    [Inject] private IRepository Repository { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var httpResult = await Repository.GetAsync<List<Country>>("/api/countries");
        Thread.Sleep(3000);
        countries = httpResult.Response;
    }
}