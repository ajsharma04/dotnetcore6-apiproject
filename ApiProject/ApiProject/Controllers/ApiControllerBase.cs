using ApiProject.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiProject.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        
    }
}
