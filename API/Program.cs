using API.Extensions;
using API.Helpers;
using API.Middlewares;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine(args);
// Add services to the container.
// Order not matter
builder.Services.AddDbContext<StoreContext>
(
    options =>
    options.UseSqlServer
    (
    builder.Configuration.GetConnectionString("connectionKey")
     , b=>b.MigrationsAssembly(@"Infrastructure")
    )
);
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCors(policy=>
{
    policy.AddPolicy("CorePolicy",(policy) =>
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("https://localhost:4200")
    );
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
try
{
    var context = services.GetRequiredService<StoreContext>();
     await context.Database.MigrateAsync();
     await StoreContextSeed.SeedAsync(context,loggerFactory);
}
catch (Exception e)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(e,"An Error Occured during migration");
}
}
// Configure the HTTP request pipeline.
// Order Matter
if (app.Environment.IsDevelopment())
{
   app.UseSwaggerDocumentation();
}
app.UseMiddleware<ExceptionMiddleware>();
//when the request comes to api but we don't have an end point that matches the request then it will hit this middleware
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
//Mechanism that is used to tell the browsers to give a web application running at 
//one origin access to selected resources from a different origin 
//and for security reasons browsers restrict cross orgign 
//
app.UseCors("CorePolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
/*
core will have Entities 
infrastructure will have context
*/
#region Application Folw
/*
when we run the application this executes a process that then looks for 
a particular method inside a particular class called "Program" and method called "Main"
and then it called when it find it and it is responsible for starting the project
Main method calls "CreateHostBuilder" method which configure a host for our application
and the host that we are using the server those responsible for hosting our application
called kestrel which provided as a dot net sdk and this goes ahead and configure as 
some defaults for our application like logging 
we can add some configurations in appsettings.json and appsettings.development.json
one for development mode and the other for production mode
we can add services to the DI container by using builder.services.add(service) 
to be availabe to other parts of the code
*/
#endregion