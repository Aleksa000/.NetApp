#nullable disable
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace USP.Data;

[CollectionName("works")]
public class Work : Base
{
 
    [BsonElement("name")]
    public string Name  { get; set; }
    
}