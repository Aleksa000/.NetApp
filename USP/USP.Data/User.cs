#nullable disable
using MongoDbGenericRepository.Attributes;

namespace USP.Data;

[CollectionName("users")]
public class User : Base
{
    public string FullName { get; set; }
}