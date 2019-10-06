using Cf.Libs.Core;
using Cf.Libs.DataAccess;
using Cf.Libs.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Laundry.Api.Configurations
{
    public static class ServiceConfigure
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddCoreService();
            services.AddRepositories();
            services.AddServices();
        }
    }
}