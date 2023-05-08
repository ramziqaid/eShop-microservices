using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task <Product> GetProductById (string productId);

        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByCategory(string category);

        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProductById(string productId);

    }
}
