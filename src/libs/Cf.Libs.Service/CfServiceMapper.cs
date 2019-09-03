using AutoMapper;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.Service.Dtos.Adresss;
using Cf.Libs.Service.Dtos.Item;
using Cf.Libs.Service.Dtos.ItemRate;
using Cf.Libs.Service.Dtos.Method;

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

            CreateMap<ItemRateRequest, ItemRate>();
            CreateMap<ItemRate, ItemRateDto>();

            CreateMap<MethodRequest, Method>();
            CreateMap<Method, MethodDto>();

            CreateMap<AddressRequest, DataAccess.Entities.Common.Address>();
            CreateMap<DataAccess.Entities.Common.Address, AddressDto>();
            CreateMap<DataAccess.Entities.Common.Address, AddressUnitDto>();
        }
    }
}