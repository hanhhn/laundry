using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cf.Libs.DataAccess.DbContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// cmd in \src\api\Cf.Laundry
        /// dotnet ef migrations add init -p G:\laundry\src\libs\Cf.Libs.DataAccess\Cf.Libs.DataAccess.csproj
        /// dotnet ef database update
        /// </summary>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = "server=127.0.0.1;port=5432;database=laundry;user id=postgres;password=@chocon";
            builder.UseNpgsql(connectionString ?? "")
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
