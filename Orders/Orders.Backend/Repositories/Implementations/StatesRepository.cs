using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Repositories.Interfaces;
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

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        var states = await _context.States.Include(s => s.Cities).ToListAsync();

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