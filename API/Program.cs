using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StoreContext>
(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionKey"))
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
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