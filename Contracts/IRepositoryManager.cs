using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    //Unit Of Work
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        ISellerRepository Seller { get; }

        Task SaveAsync();

    }
}
