using Cf.Libs.Service.Addresses;
using Cf.Libs.Service.Billing;
using Cf.Libs.Service.Contacts;
using Cf.Libs.Service.Items;
using Cf.Libs.Service.Methods;
using Cf.Libs.Service.Orders;
using Cf.Libs.Service.Pages;
using Cf.Libs.Service.Posts;
using Cf.Libs.Service.Prices;
using Cf.Libs.Service.Profile;
using Cf.Libs.Service.Settings;
using Cf.Libs.Service.Trackings;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.Service
{
    public static class CfServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IPriceService, PricesService>();
            services.AddScoped<IMethodService, MethodService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ITrackingService, TrackingService>();
            services.AddScoped<IBillingService, BillingService>();
        }
    }
}