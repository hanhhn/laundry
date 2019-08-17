using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Laundry.Configurations
{
    public static class DbContextConfigure
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnectionString = configuration.GetValue<string>("DefaultConnectionString");

            services
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(sqlConnectionString))
                .AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
        }
    }
}