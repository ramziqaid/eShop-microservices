using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public interface ICatalogDbContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
