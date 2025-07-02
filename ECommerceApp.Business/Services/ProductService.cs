using ECommerceApp.Data.Repositories;
using ECommerceApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productsRepository;

        public ProductService(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productsRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productsRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _productsRepository.AddAsync(product);
            await _productsRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _productsRepository.Update(product);
            await _productsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            if (product != null)
            {
                _productsRepository.Delete(product);
                await _productsRepository.SaveChangesAsync();
            }
        }
    }
}
