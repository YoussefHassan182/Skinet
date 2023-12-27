using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;
namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory){
            try
            {
                if (!context.ProductBrands.Any())
                {
                    //Read the Json from file
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    //Serialize the Json Object to C# Object
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                 if (!context.ProductTypes.Any())
                {
                    //Read the Json from file
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    //Serialize the Json Object to C# Object
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                 if (!context.Products.Any())
                {
                    //Read the Json from file
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    //Serialize the Json Object to C# Object
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}