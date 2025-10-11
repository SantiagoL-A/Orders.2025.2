using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWorks.Interfaces;
using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.UnitsOfWorks.Implementations;

public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
{
    private readonly ICountriesRepository _countriesRepository;

    public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository countriesRepository) : base(repository)
    {
        _countriesRepository = countriesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination) => await _countriesRepository.GetAsync(pagination)
;

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await _countriesRepository.GetAsync();

    public override async Task<ActionResponse<Country>> GetAsync(int id) => await _countriesRepository.GetAsync(id);
}