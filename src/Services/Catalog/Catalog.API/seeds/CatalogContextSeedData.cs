using Catalog.API.Entities;
using JsonFlatFileDataStore;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Catalog.API.seeds
{
    public static class CatalogContextSeedData
    {
        public static void SeedProducts(IMongoCollection<Product> Products)
        {
            bool isexsits = Products.Find(p => true).Any();
            if (!isexsits)
            {
                Products.InsertMany(getProductsList());
            }
        }
        private static IEnumerable<Product> getProductsList()
        {
            var store = new DataStore(@"seeds\products.json");
            // Get customer collection
            var collection = store.GetCollection<Product>();
            // Find item with name
            var userDynamic = collection
                                  .AsQueryable()
                                  .ToList()                                  ;
            var d=(IEnumerable<Product>) userDynamic;
            return d;
            
        }
    }
}
