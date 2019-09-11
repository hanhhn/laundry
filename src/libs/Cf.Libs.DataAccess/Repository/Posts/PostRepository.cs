using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.News;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Posts
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Post GetByUrl(string url)
        {
            return DbSet.Where(x => x.UniqueUrl == url).SingleOrDefault();
        }
    }
}