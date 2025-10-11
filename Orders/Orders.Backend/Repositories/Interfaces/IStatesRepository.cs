using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.Repositories.Interfaces;

public interface IStatesRepository
{
    Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    Task<ActionResponse<State>> GetAsync(int Id);

    Task<ActionResponse<IEnumerable<State>>> GetAsync();
}