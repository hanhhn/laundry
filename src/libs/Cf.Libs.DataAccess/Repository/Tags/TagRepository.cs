using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Common;
using Cf.Libs.DataAccess.Entities.News;
using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Tags
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Tag> GetByPost(string postId)
        {
            return DbSet.Where(x => x.PostId == postId).AsEnumerable();
        }
    }
}