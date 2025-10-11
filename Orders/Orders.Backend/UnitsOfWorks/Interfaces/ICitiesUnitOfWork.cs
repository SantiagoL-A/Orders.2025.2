using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.UnitsOfWorks.Interfaces;

public interface ICitiesUnitOfWork
{
    Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
}