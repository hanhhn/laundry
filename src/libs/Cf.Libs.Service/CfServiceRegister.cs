using Cf.Libs.Service.ItemRates;
using Cf.Libs.Service.Items;
using Cf.Libs.Service.Methods;
using Cf.Libs.Service.Profile;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.Service
{
    public static class CfServiceRegister
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRateService, ItemRateService>();
            services.AddScoped<IMethodService, MethodService>();
        }
    }
}