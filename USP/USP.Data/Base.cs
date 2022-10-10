using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace USP.Data;

public class Base
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
}