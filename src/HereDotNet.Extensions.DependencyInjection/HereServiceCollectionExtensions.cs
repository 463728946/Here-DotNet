using HereDotNet.Core;
using HereDotNet.Core.Configuration;
using HereDotNet.Extensions.DependencyInjection;
using System;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class HereServiceCollectionExtensions
    {       
        public static IServiceCollection AddHereDotNet(this IServiceCollection service, Action<IHereConfigurationBuilder> configure)
        {
            var builder = new DependencyInjectionBuilder(service);          
            configure.Invoke(builder);
           
            return service;
        }
    }
}
