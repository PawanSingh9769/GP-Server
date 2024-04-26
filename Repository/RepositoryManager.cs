using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ISellerRepository> _sellerRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _sellerRepository = new Lazy<ISellerRepository>(() => new SellerRepository(repositoryContext));


        }
        public ISellerRepository Seller => _sellerRepository.Value;
        public IProductRepository Product => _productRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
