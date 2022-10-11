using Microsoft.Extensions.Options;
using USP.Data;

namespace USP.Repositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
}
public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(IOptions<MongoSettings> mongoSettings) : base(mongoSettings)
    {
    }
}