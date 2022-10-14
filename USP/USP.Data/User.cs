#nullable disable
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Driver;
using MongoDbGenericRepository.Attributes;

namespace USP.Data;

[CollectionName("users")]
public class User : MongoIdentityUser<Guid>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string AboutMe { get; set; }
}