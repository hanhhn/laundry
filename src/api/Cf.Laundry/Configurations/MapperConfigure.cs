using AutoMapper;
using Cf.Libs.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cf.Laundry.Configurations
{
    public static class MapperConfigure
    {
        public static void AddMapper(this IServiceCollection services)
        {
            Action<IMapperConfigurationExpression> InitMapper = config =>
            {
                config.AddCoreMapper();
            };

            var configuration = new MapperConfiguration(InitMapper);
            configuration.CompileMappings();
            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}