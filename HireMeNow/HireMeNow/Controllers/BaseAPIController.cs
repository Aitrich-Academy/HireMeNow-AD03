using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowAD03.Controllers
{
    [Route("api/v1")]
[ApiController]
public abstract class BaseAPIController<T> : ControllerBase
{
}
   
}
