using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.Entities.Common;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Repository.Tags
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        IEnumerable<Tag> GetByPost(string postId);
    }
}