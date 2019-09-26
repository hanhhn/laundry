using AutoMapper;
using Cf.Libs.DataAccess.Entities.Billing;
using Cf.Libs.DataAccess.Entities.Common;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Entities.News;
using Cf.Libs.DataAccess.Entities.Orders;
using Cf.Libs.DataAccess.Entities.Static;
using Cf.Libs.Service.Dtos.Adress;
using Cf.Libs.Service.Dtos.Billing;
using Cf.Libs.Service.Dtos.Contact;
using Cf.Libs.Service.Dtos.Item;
using Cf.Libs.Service.Dtos.Method;
using Cf.Libs.Service.Dtos.Order;
using Cf.Libs.Service.Dtos.Page;
using Cf.Libs.Service.Dtos.Post;
using Cf.Libs.Service.Dtos.Price;
using Cf.Libs.Service.Dtos.Setting;
using Cf.Libs.Service.Dtos.Tracking;

namespace Cf.Libs.Service
{
    public static class CfServiceMapper
    {
        public static void AddCoreMapper(this IMapperConfigurationExpression configAction)
        {
            configAction.AddProfile<CfServiceProfile>();
        }
    }

    public class CfServiceProfile : AutoMapper.Profile
    {
        public CfServiceProfile()
        {
            CreateMap<ItemRequest, Item>();
            CreateMap<Item, ItemDto>();

            CreateMap<PriceRequest, Price>();
            CreateMap<Price, PriceDto>();

            CreateMap<MethodRequest, Method>();
            CreateMap<Method, MethodDto>();
            
            CreateMap<AddressRequest, Address>();
            CreateMap<Address, AddressDto>();
            CreateMap<Province, AddressUnitDto>();
            CreateMap<District, AddressUnitDto>();
            CreateMap<Ward, AddressUnitDto>();
            CreateMap<ContactRequest, Contact>();

            CreateMap<OrderRequest, Address>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, MethodDto>()
                .ForMember(x => x.Id, y => y.MapFrom(a => a.MethodId))
                .ForMember(x => x.Name, y => y.MapFrom(a => a.MethodName))
                .ForMember(x => x.Description, y => y.MapFrom(a => a.Description))
                .ForMember(x => x.Type, y => y.MapFrom(a => a.Type));
            CreateMap<Tracking, TrackingDto>();
            CreateMap<OrderDetail, OrderDetailDto>();


            CreateMap<Post, PostDto>();
            CreateMap<PostRequest, Post>();
            CreateMap<Tag, TagDto>();

            CreateMap<JumbotronDto, ItemCombo>();

            CreateMap<PageRequest, Page>();
            CreateMap<Page, PageDto>();

            CreateMap<Bill, BillDto>();
            CreateMap<BillDetail, BillDetailDto>();
        }
    }
}