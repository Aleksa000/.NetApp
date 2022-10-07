using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace USP.Data;

public class Product
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
    [BsonElement("name")]
    public string? Name  { get; set; }
    
    [BsonElement("price")]
    public int? Price  { get; set; }
    
    [BsonElement("category")]
    public string? Category  { get; set; }
    
}