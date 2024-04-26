using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        

        public async Task<IEnumerable<Product>> GetAllProductAsync(Guid sellerId, bool trackChanges)
        {
           //
           //var products = await FindAll(trackChanges).Where(x => x.SellerId == sellerId).OrderBy(c => c.ProductName).ToListAsync();

            var products = await FindByCondition(x => x.SellerId.Equals(sellerId),trackChanges).ToListAsync();
            Console.WriteLine(products);
            return products;
        }

        public async Task createProduct(Guid sellerId , Product product)
        {
            product.SellerId= sellerId;
            await Create(product);
        }
    }
}
