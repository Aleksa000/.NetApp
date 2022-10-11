#nullable disable
using MongoDbGenericRepository.Attributes;

namespace USP.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[CollectionName("comments")]
public class Comment : Base
{
   
    [BsonElement("name")]
    public string Name  { get; set; }
    
    [BsonElement("product")]
    public string Product  { get; set; }
    
}