using HereDotNet.Core;
using HereDotNet.Core.Configuration;
using HereDotNet.Core.Services;
using Microsoft.Extensions.DependencyInjection;


namespace HereDotNet.Extensions.DependencyInjection
{

    public class DependencyInjectionBuilder : IHereConfigurationBuilder
    {
        public IHereConfiguration HereConfiguration { get; set; }
        private readonly IServiceCollection _service;

        public DependencyInjectionBuilder(IServiceCollection service)
        {
            _service = service;
            HereConfiguration = new HereConfiguration();                        
            _service.AddSingleton(c => HereConfiguration.RestClient);                     
        }



        public IHereConfigurationBuilder AddRouteService(string name = "ls.", string version = "/2")
        {
            _service.AddSingleton<IRouteService>(c => new RouteService(HereConfiguration, name, version));
            return this;
        }

        public IHereConfigurationBuilder AddSearchService(string name = "search.", string version = "/v1")
        {
            _service.AddSingleton<ISearchService>(c => new SearchService(HereConfiguration, name, version));
            return this;
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
