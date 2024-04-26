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

        Task<ProductDto> CreateProductAsync(Guid sellerId, ProductForCreationDto product , bool trackChanges);
    }
}
