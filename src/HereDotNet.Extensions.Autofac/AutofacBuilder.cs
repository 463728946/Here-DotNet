using Autofac;
using HereDotNet.Core;
using HereDotNet.Core.Configuration;
using HereDotNet.Core.Services;

namespace HereDotNet.Extensions.Autofac
{
    public class AutofacBuilder : IHereConfigurationBuilder
    {
        public HereConfiguration HereConfiguration { get; set; }

        private readonly ContainerBuilder _builder;
        public AutofacBuilder(ContainerBuilder builder)
        {
            _builder = builder;           
            HereConfiguration = new HereConfiguration();                   
        }
        public IHereConfigurationBuilder AddRouteService(string name = "ls.", string version = "/2")
        {
            _builder.Register<IRouteService>(c => new RouteService(HereConfiguration, name, version)).InstancePerLifetimeScope();
            return this;
        }

        public IHereConfigurationBuilder AddSearchService(string name = "search.", string version = "/v1")
        {
            _builder.Register<ISearchService>(c => new SearchService(HereConfiguration, name, version)).InstancePerLifetimeScope();
            return this;
        }

        public IHereConfigurationBuilder UseApiKey(string apikey)
        {            
            HereConfiguration.UseApiKey(apikey);
            return this;
        }

        public IHereConfigurationBuilder UseJwt(string token)
        {
            HereConfiguration.UseJwt(token);
            return this;
        }

        public IHereConfigurationBuilder UseUserPassword(string user, string password)
        {            
            HereConfiguration.UseUserPassword(user, password);
            return this;
        }
    }
}
