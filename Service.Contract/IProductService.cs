using Shared.DataTransferObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IProductService
    {
       Task<IEnumerable<ProductDto>> GetAllProductsAsync(Guid sellerId, bool trackChanges);
        Task<ProductDto> GetProductAsync(Guid sellerId, Guid productId, bool trackChanges);
        Task<ProductDto> CreateProductAsync(Guid sellerId, ProductForCreationDto product , bool trackChanges);
       Task UpdateProductById(Guid sellerId, Guid productId, ProductforUpdateDto productForUpdate,bool selltrackChanges, bool prodtrackChanges);
        Task DeleteProductAsync(Guid sellerId , Guid productId, bool trackChanges);
    }
}
