using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using USP.Data;

namespace USP.Repositories;

public interface IBaseRepository<TEntity>
{
    List<TEntity> GetAll();
    long NumberOfDocuments();
    List<TEntity> PaginationSearch(int? startIndex,int? numberOfObject);
    void Insert(TEntity obj);
    void Delete(TEntity obj);

    TEntity GetOne(ObjectId id);

    void Update(TEntity obj);
}

public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : Base
{
    private readonly IMongoClient _mongoClient;//pravimo konekciju sa bazom da bi uspeli da se logujemo
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoCollection<TEntity> _mongoCollection;
    public BaseRepository(IOptions<MongoSettings> mongoSettings)//za citanje iz appsettings fajla
    {
        _mongoClient = new MongoClient(mongoSettings.Value.Connection);//imamo objekat za konekciju 
        _mongoDatabase = _mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);//konektuje se na odredjenu bazu podataka
        var test = typeof(TEntity).CustomAttributes;
        _mongoCollection = _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).CustomAttributes.FirstOrDefault()!.ConstructorArguments.FirstOrDefault().Value!.ToString());//citamo tip nepoznatog entiteta,citamo atribute,prva anotacija,njegove argumente
    }
    /// <summary>
    /// Get all object from db 
    /// </summary>
    /// <returns></returns>
    public List<TEntity> GetAll()
    {
        var filter = Builders<TEntity>.Filter.Empty;
        return _mongoCollection.Find(filter).ToList();
    }

    /// <summary>
    /// number of documents
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public long NumberOfDocuments()
    {
        var filter = Builders<TEntity>.Filter.Empty;
        return _mongoCollection.CountDocuments(filter);
    }
    /// <summary>
    /// pagination search
    /// </summary>
    /// <returns></returns>
    public List<TEntity> PaginationSearch(int? startIndex,int? numberOfObject)
    {
        var filter = Builders<TEntity>.Filter.Empty;
        return _mongoCollection.Find(filter).Skip(startIndex*numberOfObject).Limit(numberOfObject).ToList();//koliko obj preskacemo,limit koliko ih imamo
    }
    /// <summary>
    /// insert db metod
    /// </summary>
    /// <param name="obj"></param>
    public void Insert(TEntity obj)
    {
        _mongoCollection.InsertOne(obj);
    }
    /// <summary>
    /// delte metod
    /// </summary>
    /// <param name="obj"></param>
    public void Delete(TEntity obj)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id",obj.Id);
        _mongoCollection.DeleteOne(filter);
    }
    /// <summary>
    /// get one metod
    /// </summary>
    /// <returns></returns>
    public TEntity GetOne(ObjectId id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id",id);
        return _mongoCollection.Find(filter).FirstOrDefault();
    
    }

    /// <summary>
    /// update metod
    /// </summary>
    /// <param name="obj"></param>
    public void Update(TEntity obj)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id",obj.Id);
        _mongoCollection.ReplaceOne(filter, obj);
    }
}