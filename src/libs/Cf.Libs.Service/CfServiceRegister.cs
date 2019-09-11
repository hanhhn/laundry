using Cf.Libs.Service.Addresses;
using Cf.Libs.Service.Items;
using Cf.Libs.Service.Methods;
using Cf.Libs.Service.OrderDetails;
using Cf.Libs.Service.Orders;
using Cf.Libs.Service.Posts;
using Cf.Libs.Service.Prices;
using Cf.Libs.Service.Profile;
using Cf.Libs.Service.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.Service
{
    public static class CfServiceRegister
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IPriceService, PricesService>();
            services.AddScoped<IMethodService, MethodService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IPostService, PostService>();
        }
    }
}