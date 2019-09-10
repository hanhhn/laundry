using Cf.Libs.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Cf.Laundry.Configurations
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
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            builder.UseNpgsql(connectionString ?? "server=127.0.0.1;port=5432;database=laundry;user id=postgres;password=@chocon")
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            return new ApplicationDbContext(builder.Options);
        }
    }
}