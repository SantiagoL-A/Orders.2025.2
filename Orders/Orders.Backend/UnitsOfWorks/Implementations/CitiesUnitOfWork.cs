using Orders.Backend.Repositories.Implementations;
using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWorks.Interfaces;
using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.UnitsOfWorks.Implementations;

public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
{
    private readonly ICitiesRepository _citiesRepository;

    public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
    {
        _citiesRepository = citiesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => await _citiesRepository.GetAsync(pagination);

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _citiesRepository.GetTotalRecordsAsync(pagination);
}