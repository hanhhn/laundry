using AutoMapper;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.Service.Dtos.Item;

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
        }
    }
}
