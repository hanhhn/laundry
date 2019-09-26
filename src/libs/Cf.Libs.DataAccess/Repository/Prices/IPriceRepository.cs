using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.Entities.Items;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Prices
{
    public interface IPriceRepository : IBaseRepository<Price>
    {
        IQueryable<Price> FindByItem();
        IQueryable<Price> FindByMethod();
        Price GetRate(int itemId);
    }
}