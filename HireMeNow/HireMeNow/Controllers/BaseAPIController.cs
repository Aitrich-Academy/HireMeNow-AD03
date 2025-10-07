using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowAD03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseAPIController<T> : ControllerBase
    {
    }
}
