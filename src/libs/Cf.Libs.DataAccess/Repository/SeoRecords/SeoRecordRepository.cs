using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Common;

namespace Cf.Libs.DataAccess.Repository.SeoRecords
{
    public class SeoRecordRepository : BaseRepository<District>, ISeoRecordRepository
    {
        public SeoRecordRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}