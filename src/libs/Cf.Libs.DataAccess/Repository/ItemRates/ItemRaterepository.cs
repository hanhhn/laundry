using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Items;

namespace Cf.Libs.DataAccess.Repository.ItemRates
{
    public class ItemRateRepository : BaseRepository<ItemRate>, IItemRateRepository
    {
        public ItemRateRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}