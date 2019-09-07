using Cf.Libs.DataAccess.Repository.OrderDetails;
using Cf.Libs.DataAccess.Repository.Orders;
using Cf.Libs.Service.Addresses;
using Cf.Libs.Service.Items;
using Cf.Libs.Service.Methods;
using Cf.Libs.Service.Prices;
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
            services.AddScoped<IPriceService, PricesService>();
            services.AddScoped<IMethodService, MethodService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        }
    }
}