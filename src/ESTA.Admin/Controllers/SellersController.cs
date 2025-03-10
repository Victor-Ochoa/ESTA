using ESTA.Domain.Contract.Repository;
using ESTA.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ESTA.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellersController(IRepositoryEntity<Seller> repository) : BaseCRUDController<Seller>(repository);