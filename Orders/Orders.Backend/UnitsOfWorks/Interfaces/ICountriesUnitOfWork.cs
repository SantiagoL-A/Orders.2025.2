using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.UnitsOfWorks.Interfaces;

public interface ICountriesUnitOfWork
{
    Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<Country>> GetAsync(int Id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}