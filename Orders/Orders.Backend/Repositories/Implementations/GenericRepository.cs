using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Orders.Backend.Data;
using Orders.Backend.Helpers;
using Orders.Backend.Repositories.Interfaces;
using Orders.shared.DTOs;
using Orders.shared.Responses;

namespace Orders.Backend.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _entity;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _entity = context.Set<T>();
    }

    public virtual async Task<ActionResponse<T>> AddAsync(T entity)
    {
        _context.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSucces = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            {
                Message = "Registro no encontrado"
            };
        }
        _entity.Remove(row);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSucces = true,
            };
        }
        catch
        {
            return new ActionResponse<T>
            {
                Message = "No se puede borrar porque tiene registros relacionados"
            };
        }
    }

    public virtual async Task<ActionResponse<T>> GetAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<T>
        {
            WasSucces = true,
            Result = row
        };
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => new ActionResponse<IEnumerable<T>>
    {
        WasSucces = true,
        Result = await _entity.ToListAsync()
    };

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        _context.Update(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSucces = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    private ActionResponse<T> ExceptionActionResponse(Exception exception) => new ActionResponse<T>
    {
        Message = exception.Message,
    };

    private ActionResponse<T> DbUpdateExceptionActionResponse() => new ActionResponse<T>
    {
        Message = "Ya existe el registro."
    };

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _entity.AsQueryable();

        return new ActionResponse<IEnumerable<T>>
        {
            WasSucces = true,
            Result = await queryable.paginate(pagination).ToListAsync()
        };
    }

    public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _entity.AsQueryable();
        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSucces = true,
            Result = (int)count
        };
    }
}