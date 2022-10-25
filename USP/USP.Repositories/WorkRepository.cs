using Microsoft.Extensions.Options;
using USP.Data;

namespace USP.Repositories;

public interface IWorkRepository : IBaseRepository<Work>
{
}
public class WorkRepository : BaseRepository<Work>, IWorkRepository
{
    public WorkRepository(IOptions<MongoSettings> mongoSettings) : base(mongoSettings)
    {
    }
}