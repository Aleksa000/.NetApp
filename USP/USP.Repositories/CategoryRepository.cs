using Microsoft.Extensions.Options;
using USP.Data;

namespace USP.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
}
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IOptions<MongoSettings> mongoSettings) : base(mongoSettings)
    {
    }
}