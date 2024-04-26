using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                ProductName = "Premium Laptop",
                ProductDescription = "Experience unparalleled performance and sleek design with our Premium Laptop," +
                                        " featuring cutting-edge technology for lightning-fast processing, vibrant visuals, and long-lasting battery life..",
                Price = 99, // Example price
                SellerId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")
            },
            new Product
            {
                Id = new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), // Unique GUID for the product
                ProductName = "Smartphone",
                ProductDescription = "Experience the latest in mobile tech with our Smartphone. " +
                         "Stunning display, powerful camera, and seamless performance.",
                Price = 499 ,// Example price
                SellerId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")
            });
        }

    }
}
