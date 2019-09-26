using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Billing;

namespace Cf.Libs.DataAccess.Repository.BillDetails
{
    public class BillDetailRepository : BaseRepository<BillDetail>, IBillDetailRepository
    {
        public BillDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}