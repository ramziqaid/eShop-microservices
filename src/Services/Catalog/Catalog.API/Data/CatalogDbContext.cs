using Catalog.API.Entities;
using Catalog.API.seeds;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogDbContext: ICatalogDbContext
    {
        public CatalogDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeedData.SeedProducts(Products);
        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
