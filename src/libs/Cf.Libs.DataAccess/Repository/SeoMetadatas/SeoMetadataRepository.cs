using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Common;

namespace Cf.Libs.DataAccess.Repository.SeoMetadatas
{
    public class SeoMetadataRepository : BaseRepository<District>, ISeoMetadataRepository
    {
        public SeoMetadataRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}