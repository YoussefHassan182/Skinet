using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger<ExceptionMiddleware> _Logger;
        private readonly IHostEnvironment _Env;
        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware>logger,IHostEnvironment env)
        {
           _Next= next;
            _Logger = logger;
            _Env= env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
try
{
   await _Next(context);
}
catch (Exception ex)
{
    
  _Logger.LogError(ex,ex.Message);
  context.Response.ContentType ="application/json";
  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
  var response = _Env.IsDevelopment() ?
   new APIExceptions((int)HttpStatusCode.InternalServerError,
  ex.Message,ex.StackTrace.ToString()) :
  new APIExceptions((int)HttpStatusCode.InternalServerError);
  var options = new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
var json = JsonSerializer.Serialize(response,options);
await context.Response.WriteAsJsonAsync(json);
}
        }
    }
}