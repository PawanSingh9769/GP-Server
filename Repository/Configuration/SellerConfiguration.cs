using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasData(new Seller
            {
                Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), // Manual GUID for Walmart
                Name = "Walmart",
                Description = "Walmart is a multinational retail corporation known for its wide range of products and affordable prices.",
                ContactInformation = "123-456-7890" // Example contact information
            },
             new Seller
             {
                 Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                 Name = "Amazon",
                 Description = "Amazon is a global e-commerce platform offering a vast selection of products and services.",
                 ContactInformation = "amazon@example.com" // Example contact information

             },
             new Seller
             {
                 Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                 Name = "Target",
                 Description = "Target is a retail chain offering trendy merchandise, essentials, and more.",
                 ContactInformation = "target@store.com" // Example contact information

             });

        }
    }
}
