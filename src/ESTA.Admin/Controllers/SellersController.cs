using ESTA.Domain.Entity;
using ESTA.Domain.Shared.Contract.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ESTA.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellersController(IRepositoryEntity<Seller> repository) : BaseCRUDController<Seller>(repository);