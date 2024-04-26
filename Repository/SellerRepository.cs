using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SellerRepository : RepositoryBase<Seller> , ISellerRepository
    {
        public SellerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<Seller>> GetAllSellerAsync(bool trackChanges)
        {
            var seller = await FindAll(trackChanges).ToListAsync();
            return  seller;
        }



        public async Task CreateSeller(Seller seller)
        {
           await Create(seller);
        }

        public  async Task<Seller> GetSellerAsync(Guid sellerId, bool trackChanges)
        {
            try
            {
                var response =  await FindByCondition(c => c.Id.Equals(sellerId), trackChanges).AsNoTracking().SingleOrDefaultAsync();
                return response;

            }
            catch(Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

        }


        //public async Task UpdateSellerById(Guid id, Seller seller)
        //{
        //    var sellerExist = await RepositoryContext.Set<Seller>().FindAsync(id);
        //    //throw exception

        //    Update(sellerExist);

        //}

        //public Task DeleteSellerAsync(Guid id)
        //{
        //   await Delete(id);
        //}




    }
}
