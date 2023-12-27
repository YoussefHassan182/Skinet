using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=>p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.HasOne(p=>p.ProductBrand).WithMany().HasForeignKey(x=>x.ProductBrandId);
            builder.HasOne(p=>p.ProductType).WithMany().HasForeignKey(x=>x.ProductTypeId);
        }
    }
}