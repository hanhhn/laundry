using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.Entities.News;

namespace Cf.Libs.DataAccess.Repository.Posts
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Post GetByUrl(string url);
    }
}