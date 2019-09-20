using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Orders;

namespace Cf.Libs.DataAccess.Repository.Trackings
{
    public class TrackingRepository : BaseRepository<Tracking>, ITrackingRepository
    {
        public TrackingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}