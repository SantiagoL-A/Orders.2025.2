using System.Linq;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Helpers;
using Orders.Backend.Repositories.Interfaces;
using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.Repositories.Implementations;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly DataContext _context;

    public CountriesRepository(DataContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    {
        var countries = await _context.Countries.Include(x => x.States).ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            WasSucces = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Countries.Include(c => c.States).AsQueryable();

        return new ActionResponse<IEnumerable<Country>>
        {
            WasSucces = true,
            Result = await queryable.OrderBy(x => x.Name).paginate(pagination).ToListAsync()
        };
    }

    public override async Task<ActionResponse<Country>> GetAsync(int id)
    {
        var country = await _context.Countries.Include(x => x.States!).ThenInclude(x => x.Cities).FirstOrDefaultAsync(x => x.Id == id);

        return new ActionResponse<Country>
        {
            WasSucces = true,
            Result = country
        };
    }
}