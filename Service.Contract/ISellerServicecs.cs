using Shared.DataTransferObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface ISellerService
    {
        Task<IEnumerable<SellerDto>> GetAllSellerAsync(bool trackChanges);
        Task<SellerDto> CreateSeller(SellerForCreationDto Selller);

        Task<SellerDto>  GetSellerAsync(Guid id , bool trackChanges);

       // Task UpdateSellerById(Guid id, SellerForUpdateDto sellerForUpdateDto, bool trackChanges);
       Task UpdateSellerById(Guid id, SellerForCreationDto sellerForUpdateDto, bool trackChanges);
    }
}
