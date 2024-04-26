using Entities.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext( DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                          //This is required for migration to work properly
            modelBuilder.ApplyConfiguration(new ProductConfiguration());       //This line tells EF Core to apply the configuration specified 
                                                                              //in the CompanyConfiguration class to the corresponding entity (Company) 
                                                                             //in your DbContext
            modelBuilder.ApplyConfiguration(new SellerConfiguration());
           modelBuilder.ApplyConfiguration(new RolesConfiguration());

        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Seller>? Sellers { get; set;}
    }
}
 