using AutoMapper;
using Cf.Libs.Service;
using System;

namespace Cf.Laundry.Configurations
{
    public static class MapperConfigure
    {
        public static void AddMapper()
        {
            Action<IMapperConfigurationExpression> InitMapper = config =>
            {
                config.AddCoreMapper();
            };
            Mapper.Initialize(InitMapper);
        }
    }
}