using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Common;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Addresses
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Address> FindByPhone(string phone)
        {
            var query = from item in DbSet
                        where !item.IsDeleted && item.Phone == phone
                        orderby item.IsDefault descending
                        orderby item.ModifiedDate descending
                        orderby item.CreateDate descending
                        orderby item.Id ascending
                        select item;
            return query;
        }
    }
}