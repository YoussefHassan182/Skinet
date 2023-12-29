using API.DTOs;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _Config;
        public ProductUrlResolver(IConfiguration config)
        {
            _Config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {    if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _Config["ApiUrl"]+source.PictureUrl;
            }
            return "No Image";
        }
    }
}