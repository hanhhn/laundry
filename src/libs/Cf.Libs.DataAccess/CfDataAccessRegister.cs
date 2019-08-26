using Cf.Libs.DataAccess.Repository.Addresses;
using Cf.Libs.DataAccess.Repository.ItemRates;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.DataAccess.Repository.Methods;
using Cf.Libs.DataAccess.Repository.OrderDetails;
using Cf.Libs.DataAccess.Repository.Orders;
using Cf.Libs.DataAccess.Repository.Settings;
using Cf.Libs.DataAccess.Repository.UserProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.DataAccess
{
    public static class CfDataAccessRegister
    {
        public static void AddCoreRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IItemRateRepository, ItemRateRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IMethodRepository, MethodRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }
    }
}