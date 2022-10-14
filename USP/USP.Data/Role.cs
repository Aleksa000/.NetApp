using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace USP.Data;
[CollectionName("rols")]
public class Role : MongoIdentityRole<Guid>
{
    
}