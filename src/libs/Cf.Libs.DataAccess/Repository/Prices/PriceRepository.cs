using Cf.Laundry.Common;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Items;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Prices
{
    public class PriceRepository : BaseRepository<Price>, IPriceRepository
    {
        public PriceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Price> FindByItem()
        {
            return FindByItemCode(ItemCode.Item.ToString());
        }

        public IQueryable<Price> FindByMethod()
        {
            return FindByItemCode(ItemCode.Method.ToString());
        }

        private IQueryable<Price> FindByItemCode(string code)
        {
            var query = from rate in DbSet
                        where !rate.IsDeleted && rate.ItemCode == code
                        orderby rate.ModifiedDate descending
                        orderby rate.CreateDate descending
                        select rate;
            return query;
        }
    }
}