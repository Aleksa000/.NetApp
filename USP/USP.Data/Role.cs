using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace USP.Data;
[CollectionName("roles")]
public class Role : MongoIdentityRole<Guid>
{
    
}