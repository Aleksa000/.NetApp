#nullable disable
using MongoDbGenericRepository.Attributes;

namespace USP.Data;

using MongoDB.Bson.Serialization.Attributes;

[CollectionName("categories")]
public class Category : Base
{
   
    [BsonElement("name")]
    public string Name  { get; set; }
    
}