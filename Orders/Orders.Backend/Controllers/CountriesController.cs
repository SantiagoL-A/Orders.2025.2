using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.UnitsOfWorks.Interfaces;
using Orders.shared.DTOs;
using Orders.shared.Entities;
using Orders.shared.Responses;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : GenericController<Country>
{
    private readonly ICountriesUnitOfWork _countriesUnitOfWork;

    public CountriesController(IGenericUnitOfWork<Country> unitOfWork, ICountriesUnitOfWork countriesUnitOfWork) : base(unitOfWork)
    {
        _countriesUnitOfWork = countriesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var reponse = await _countriesUnitOfWork.GetAsync(pagination);
        if (reponse.WasSucces)
        {
            return Ok(reponse.Result);
        }
        return BadRequest();
    }

    [HttpGet]
    public override async Task<IActionResult> GetActionAsync()
    {
        var action = await _countriesUnitOfWork.GetAsync();
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var action = await _countriesUnitOfWork.GetAsync(id);
        if (action.WasSucces)
        {
            return Ok(action.Result);
        }
        return NotFound();
    }
}