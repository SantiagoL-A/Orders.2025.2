using Microsoft.AspNetCore.Mvc;
using Orders.Backend.UnitsOfWorks.Implementations;
using Orders.Backend.UnitsOfWorks.Interfaces;
using Orders.shared.Entities;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    private readonly IStatesUnitOfWork _statesUnitOfWork;

    public StatesController(IGenericUnitOfWork<State> unitOfWork, IStatesUnitOfWork statesUnitOfWork) : base(unitOfWork)
    {
        _statesUnitOfWork = statesUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetActionAsync()
    {
        var action = await _statesUnitOfWork.GetAsync();
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var action = await _statesUnitOfWork.GetAsync(id);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return NotFound();
    }
}