using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
     public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
     {

Services.AddAutoMapper(typeof(MappingProfiles));

Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

Services.AddScoped<IProductRepository,ProductRepository>();
//Options used to configure behavior for types annotated with ApiControllerAttribute.
Services.Configure<ApiBehaviorOptions>(options=>
{
//Delegate invoked on actions annotated with ApiControllerAttribute 
//to convert invalid Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary into an IActionResult
options.InvalidModelStateResponseFactory= 
//Delegate invoked on actions annotated with ApiControllerAttribute to convert invalid
// Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary into an IActionResult
actionContext =>
{
var errors = actionContext.ModelState //Gets the Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.
.Where(x=>x.Value.Errors.Count>0)
.SelectMany(x=>x.Value.Errors)//Gets the Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection for this entry.
.Select(e=>e.ErrorMessage)//Gets the error message associated with this Microsoft.AspNetCore.Mvc.ModelBinding.ModelError instance.
.ToArray();
var ErrorResponce = new APIValidationErrorResponse()
{
    Errors = errors
};
return new BadRequestObjectResult(ErrorResponce);
};
}
);
return Services;
     }   
    }
}