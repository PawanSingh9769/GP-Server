using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public  interface IServiceManager
    {
        IProductService ProductService{ get; }
        ISellerService SellerService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
