using AutoMapper;
using Cf.Libs.DataAccess.Entities.Common;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.Service.Dtos.Adress;
using Cf.Libs.Service.Dtos.Item;
using Cf.Libs.Service.Dtos.Method;
using Cf.Libs.Service.Dtos.Prices;

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
        }
    }
}