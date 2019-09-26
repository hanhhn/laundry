using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.Entities.Billing;

namespace Cf.Libs.DataAccess.Repository.Bills
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        Bill GetBill(string phone, string code);
    }
}