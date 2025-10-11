using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Helpers;
using Orders.Backend.Repositories.Interfaces;
using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.Repositories.Implementations;

public class StatesRepository : GenericRepository<State>, IStatesRepository
{
    private readonly DataContext _context;

    public StatesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.States.Include(x => x.Cities).Where(x => x.Country!.Id == pagination.Id).AsQueryable();
        return new ActionResponse<IEnumerable<State>>
        {
            WasSucces = true,
            Result = await queryable.OrderBy(x => x.Name).paginate(pagination).ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        Console.WriteLine($"Pagination.Id = {pagination.Id}");
        var queryable = _context.States.Where(x => x.Country!.Id == pagination.Id).AsQueryable();
        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSucces = true,
            Result = (int)count
        };
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        var states = await _context.States.OrderBy(x => x.Name).ToListAsync();

        return new ActionResponse<IEnumerable<State>>
        {
            WasSucces = true,
            Result = states
        };
    }

    public override async Task<ActionResponse<State>> GetAsync(int id)
    {
        var state = await _context.States.Include(s => s.Cities).FirstOrDefaultAsync(s => s.Id == id);

        return new ActionResponse<State>
        {
            WasSucces = true,
            Result = state
        };
    }
}