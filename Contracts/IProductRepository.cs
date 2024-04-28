using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductAsync(Guid sellerId , bool trackChanges);
        Task<Product> getProductAsync(Guid sellerId,Guid productId, bool trackChanges);
        Task createProduct(Guid sellerId,Product product);
        void DeleteProduct(Product product);
    }
}
