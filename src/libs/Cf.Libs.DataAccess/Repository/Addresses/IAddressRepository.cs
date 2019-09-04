using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.Entities.Common;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Addresses
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        IQueryable<Address> FindByPhone(string phone);
    }
}