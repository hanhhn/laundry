using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Items;

namespace Cf.Libs.DataAccess.Repository.Methods
{
    public class MethodRepository : BaseRepository<Method>, IMethodRepository
    {
        public MethodRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}