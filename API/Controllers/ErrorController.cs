using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    //Controls the visibility and group name for an ApiDescription 
    //of the associated controller class or action method.
    public class ErrorController : BaseAPIController
    {
      public IActionResult Error(int  code)
      {
return new ObjectResult(new APIResponse(code));
      }
    }
}