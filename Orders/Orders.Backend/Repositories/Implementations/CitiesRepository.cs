using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Helpers;
using Orders.Backend.Repositories.Interfaces;
using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.Repositories.Implementations;

public class CitiesRepository : GenericRepository<City>, ICitiesRepository
{
    private readonly DataContext _context;

    public CitiesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities
            .Where(x => x.State!.Id == pagination.Id)
            .AsQueryable();

        return new ActionResponse<IEnumerable<City>>
        {
            WasSucces = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        Console.WriteLine($"Pagination.Id = {pagination.Id}");

        var queryable = _context.Cities
            .Where(x => x.State!.Id == pagination.Id)
            .AsQueryable();

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSucces = true,
            Result = (int)count
        };
    }
}