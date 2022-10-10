using Microsoft.Extensions.Options;
using USP.Data;

namespace USP.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
}
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(IOptions<MongoSettings> mongoSettings) : base(mongoSettings)
    {
    }
}