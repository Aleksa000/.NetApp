#nullable disable
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace USP.Data;

[CollectionName("products")]
public class Product : Base
{
 
    [BsonElement("name")]
    public string Name  { get; set; }
    
    [BsonElement("price")]
    public int Price  { get; set; }
    
    [BsonElement("category")]
    public string Category  { get; set; }
    
}