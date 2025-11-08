using Microsoft.AspNetCore.Mvc;
using Orders.shared.Entities;
using Orders.shared.DTOs;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Backend.UnitsOfWorks.Interfaces;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : GenericController<Category>
{
    private readonly ICategoriesUnitOfWork _categoriesUnitOfWork;

    public CategoriesController(IGenericUnitOfWork<Category> unit, ICategoriesUnitOfWork categoriesUnitOfWork) : base(unit)
    {
        _categoriesUnitOfWork = categoriesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var response = await _categoriesUnitOfWork.GetAsync(pagination);
        if (response.WasSucces)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("totalRecords")]
    public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _categoriesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}