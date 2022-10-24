#nullable disable
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace USP.Data;

[CollectionName("comments")]
public class Comment : Base
{
 
    [BsonElement("name")]
    public string Name  { get; set; }
    
    [BsonElement("review")]
    public string Review  { get; set; }
    
    [BsonElement("category")]
    public string Category  { get; set; }
    
    [BsonElement("type")]
    public string Type  { get; set; }

    
    
}