using ESTA.Domain.Contract.Repository;
using ESTA.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESTA.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellersController(IRepositoryEntity<Seller> repository) : BaseCRUDController<Seller>(repository)
{
}