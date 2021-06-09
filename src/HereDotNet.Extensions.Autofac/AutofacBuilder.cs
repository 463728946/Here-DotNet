using Autofac;
using HereDotNet.Core;
using HereDotNet.Core.Configuration;
using HereDotNet.Core.Services;

namespace HereDotNet.Extensions.Autofac
{
    public class AutofacBuilder : IHereConfigurationBuilder
    {
        public IHereConfiguration HereConfiguration { get; set; }

        private readonly ContainerBuilder _builder;
        public AutofacBuilder(ContainerBuilder builder)
        {
            _builder = builder;
            HereConfiguration = new HereConfiguration();            
            builder.Register(c => HereConfiguration).SingleInstance();
            builder.Register(c => HereConfiguration.RestClient).SingleInstance();
            
        }
        public IHereConfigurationBuilder AddRouteService(string name = "ls.", string version = "/2")
        {
            _builder.Register<IRouteService>(c => new RouteService(HereConfiguration, name, version)).SingleInstance();
            return this;
        }

        public IHereConfigurationBuilder AddSearchService(string name = "search.", string version = "/v1")
        {
            _builder.Register<ISearchService>(c => new SearchService(HereConfiguration, name, version)).SingleInstance();
            throw new System.NotImplementedException();
        }

        public IHereConfigurationBuilder UseApiKey(string apikey)
        {
            HereConfiguration.AuthType = AuthType.ApiKey;
            HereConfiguration.AuthValue = apikey;
            return this;
        }

        public IHereConfigurationBuilder UseJwt(string token)
        {
            HereConfiguration.AuthType = AuthType.Jwt;
            HereConfiguration.AuthValue = token;
            return this;
        }

        public IHereConfigurationBuilder UseUserPassword(string user, string password)
        {           
            return this;
        }
    }
}
