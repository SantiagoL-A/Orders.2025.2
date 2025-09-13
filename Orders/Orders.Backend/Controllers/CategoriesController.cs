using Microsoft.AspNetCore.Mvc;
using Orders.shared.Entities;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : GenericController<Category>
{
    public CategoriesController(UnitsOfWorks.Interfaces.IGenericUnitOfWork<Category> unitOfWork) : base(unitOfWork)
    {
    }
}