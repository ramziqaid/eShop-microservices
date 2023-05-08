using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.API.Services
{
    public class ProductService: IProductService
    {
        public ICatalogDbContext _catalogDbContext { get; set; }
        public ProductService(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext; 
        }
         

        public async Task<IEnumerable<Product>> GetProducts()
        {
          return await _catalogDbContext.Products.Find(p =>true).ToListAsync();
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _catalogDbContext.Products.Find(p => p.Id.Equals(productId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            FilterDefinition<Product> filterDefinitionBuilder = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            return await _catalogDbContext.Products
                .Find(filterDefinitionBuilder)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            FilterDefinition<Product> filterDefinitionBuilder = Builders<Product>.Filter.Eq(p => p.Category, category);
            return await _catalogDbContext.Products
                .Find(filterDefinitionBuilder)
                .ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
           await _catalogDbContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
           var update= await _catalogDbContext.Products.ReplaceOneAsync
                (filter:p=>p.Id==product.Id,replacement:product);
            return update.IsAcknowledged && update.ModifiedCount>0;
        }

       

        public async Task<bool> DeleteProductById(string productId)
        {
            FilterDefinition<Product> filterDefinitionBuilder = Builders<Product>.Filter.Eq(p => p.Id,productId);
            var update = await _catalogDbContext.Products.DeleteOneAsync(filterDefinitionBuilder);

            return update.IsAcknowledged && update.DeletedCount > 0;
        }
    }
}
