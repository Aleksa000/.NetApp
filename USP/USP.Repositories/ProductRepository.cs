using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using USP.Data;

namespace USP.Repositories;

public interface IProductRepository
{
    List<Product> GetAll();
    void Insert(Product obj);
    void Delete(Product obj);

    Product GetOne(ObjectId id);

    void Update(Product obj);
}
public class ProductRepository : IProductRepository

{
    private readonly IMongoClient _mongoClient;//pravimo konekciju sa bazom da bi uspeli da se logujemo
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoCollection<Product> _mongoCollection;
    public ProductRepository(IOptions<MongoSettings> mongoSettings)//za citanje iz appsettings fajla
    {
        _mongoClient = new MongoClient(mongoSettings.Value.Connection);//imamo objekat za konekciju 
        _mongoDatabase = _mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);//konektuje se na odredjenu bazu podataka
        _mongoCollection = _mongoDatabase.GetCollection<Product>("products");//kreiramo mongo kolekciju
    }
/// <summary>
/// Get all object from db 
/// </summary>
/// <returns></returns>
    public List<Product> GetAll()
    {
        var filter = Builders<Product>.Filter.Empty;
        return _mongoCollection.Find(filter).ToList();
    }
/// <summary>
/// insert db metod
/// </summary>
/// <param name="obj"></param>
public void Insert(Product obj)
{
    _mongoCollection.InsertOne(obj);
}
/// <summary>
/// delte metod
/// </summary>
/// <param name="obj"></param>
public void Delete(Product obj)
{
    var filter = Builders<Product>.Filter.Eq("_id",obj.Id);
    _mongoCollection.DeleteOne(filter);
}
/// <summary>
/// get one metod
/// </summary>
/// <returns></returns>
public Product GetOne(ObjectId id)
{
    var filter = Builders<Product>.Filter.Eq("_id",id);
    return _mongoCollection.Find(filter).FirstOrDefault();
    
}

/// <summary>
/// update metod
/// </summary>
/// <param name="obj"></param>
public void Update(Product obj)
{
    var filter = Builders<Product>.Filter.Eq("_id",obj.Id);
    _mongoCollection.ReplaceOne(filter, obj);
}
}