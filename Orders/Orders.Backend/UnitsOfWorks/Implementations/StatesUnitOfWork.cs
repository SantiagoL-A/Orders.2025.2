using Orders.Backend.Repositories.Implementations;
using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWorks.Interfaces;
using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.UnitsOfWorks.Implementations;

public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
{
    private readonly IStatesRepository _statesRepository;

    public StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : base(repository)
    {
        _statesRepository = statesRepository;
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _statesRepository.GetTotalRecordsAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination) => await _statesRepository.GetAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await _statesRepository.GetAsync();

    public override Task<ActionResponse<State>> GetAsync(int id) => _statesRepository.GetAsync(id);
}