﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cf.Libs.Core.Infrastructure.Engine
{
    public class CoffeeEngine : IEngine
    {
        private IServiceProvider _serviceProvider;

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            return GetServiceProvider().GetService(type);
        }
    }
}
