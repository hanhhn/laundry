using Cf.Libs.Core.Infrastructure.Engine;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cf.Libs.Core
{
    public static class CfCoreRegister
    {
        public static void AddCoreService(this IServiceCollection services)
        {
            var engine = EngineContext.Current;
            engine.ConfigureServices(services.BuildServiceProvider());
        }
    }
}