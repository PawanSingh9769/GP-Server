using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetAllSellerAsync(bool trackChanges);


        //GetSeller By Id
        Task<Seller> GetSellerAsync(Guid sellerId, bool trackChanges);


        //Add Seller
        Task CreateSeller(Seller seller);
        void UpdateSellerById(Seller seller);
        void DeleteSeller(Seller seller);
        //update and delete can be happen in service layer as they are connected method .
        //there we don't need to write repo for update and delete
    }
}
