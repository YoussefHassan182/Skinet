using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection Services)
        {
Services.AddSwaggerGen(s=>
{
s.SwaggerDoc("v1",new OpenApiInfo
{
Title="Skinet API",
Version ="v1"
});
});

return Services;
        }
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
             app.UseSwagger();
    app.UseSwaggerUI(s=>
    {s.SwaggerEndpoint("/swagger/v1/swagger.json","Skinet API ");
    }
    );
            return app;
        }
    }
}