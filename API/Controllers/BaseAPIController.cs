using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
//Indicates that a type and all derived types are used to serve HTTP API responses.
//Controllers decorated with this attribute are configured 
//with features and behavior targeted at improving the developer experience for building APIs.
// When decorated on an assembly, all controllers in the assembly 
//will be treated as controllers with API behavior
    [ApiController] 
    [Route("api/[controller]")]
    public class BaseAPIController:ControllerBase
    {
    }
}