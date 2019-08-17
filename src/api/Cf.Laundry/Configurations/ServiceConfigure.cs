using Cf.Libs.DataAccess;
using Cf.Libs.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Laundry.Configurations
{
    public static class ServiceConfigure
    {
        public static void AddServicesAndRepository(this IServiceCollection services)
        {
            services.AddCoreRepositories();
            services.AddCoreServices();
        }
    }
}