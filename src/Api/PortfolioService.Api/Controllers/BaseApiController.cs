using Microsoft.AspNetCore.Mvc;

namespace PortfolioService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
