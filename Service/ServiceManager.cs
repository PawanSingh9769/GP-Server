using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ISellerService> _sellerService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager,
 IConfiguration configuration)
        {
            _productService = new Lazy<IProductService>(() => new  ProductService(repositoryManager, logger, mapper));
            _sellerService = new Lazy<ISellerService>(() => new SellerService(repositoryManager,logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, userManager, configuration, mapper));




        }

        public IProductService ProductService => _productService.Value;
        public ISellerService SellerService => _sellerService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;



    }
}
