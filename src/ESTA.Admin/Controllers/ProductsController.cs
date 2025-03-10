using ESTA.Domain.Contract.Repository;
using ESTA.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ESTA.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IRepositoryEntity<Product> repository) : BaseCRUDController<Product>(repository)
{
}