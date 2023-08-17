using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorDemo.Models;

namespace MediatorDemo.DataStore
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Test Product 1" },
                new Product { Id = 2, Name = "Test Product 2" },
                new Product { Id = 3, Name = "Test Product 3" }
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(product);
        }
    }
}
