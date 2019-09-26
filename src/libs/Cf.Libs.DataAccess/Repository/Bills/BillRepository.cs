using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Billing;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Bills
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override IQueryable<Bill> GetQuery()
        {
            return base.GetQuery().Include(x => x.BillDetails);
        }

        public Bill GetBill(string phone, string code)
        {
            return DbSet.Where(x => x.Phone == phone && x.OrderCode == code).SingleOrDefault();
        }
    }
}