using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.Repositories.Interfaces;

public interface ICountriesRepository
{
    Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<Country>> GetAsync(int Id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}