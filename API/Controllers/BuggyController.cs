using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiExplorerSettings(IgnoreApi =true)]
    public class BuggyController:BaseAPIController
    {
        private readonly StoreContext _Context;

        public BuggyController(StoreContext context)
        {
            _Context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _Context.Products.Find(44);
            if(thing == null)
            {
            return NotFound(new APIResponse(404));
            }
            return Ok();
        }
          [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
         var thing = _Context.Products.Find(44);
         var thingToReturn = thing.ToString();
            return Ok(new APIResponse(500));
        }  
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400));
        } 
         [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}