using Microsoft.Extensions.Options;
using MongoDB.Driver;
using USP.Data;

namespace USP.Repositories;

public interface IProductRespository
{
    List<Product> GetAll();
}
public class ProductRepository : IProductRespository

{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoCollection<Product> _mongoCollection;
    public ProductRepository(IOptions<MongoSettings> mongoSettings)
    {
        _mongoClient = new MongoClient(mongoSettings.Value.Connection);
        _mongoDatabase = _mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);
        _mongoCollection = _mongoDatabase.GetCollection<Product>("products");
    }

    public List<Product> GetAll()
    {
        var filter = Builders<Product>.Filter.Eq("", "");
        return _mongoCollection.Find(filter).ToList();
    }
}