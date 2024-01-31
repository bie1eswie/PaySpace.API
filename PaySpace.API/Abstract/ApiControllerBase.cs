using Microsoft.AspNetCore.Mvc;

namespace PaySpace.API.Abstract
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {

    }
}
