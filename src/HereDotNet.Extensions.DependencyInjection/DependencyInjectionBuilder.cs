using HereDotNet.Core;
using HereDotNet.Core.Configuration;
using HereDotNet.Core.Services;
using Microsoft.Extensions.DependencyInjection;


namespace HereDotNet.Extensions.DependencyInjection
{

    public class DependencyInjectionBuilder : IHereConfigurationBuilder
    {
        public HereConfiguration HereConfiguration { get; set; }
        private readonly IServiceCollection _service;

        public DependencyInjectionBuilder(IServiceCollection service)
        {
            _service = service;
            HereConfiguration = new HereConfiguration();                              
        }



        public IHereConfigurationBuilder AddRouteService(string name = "ls.", string version = "/2")
        {
            _service.AddScoped<IRouteService>(c => new RouteService(HereConfiguration, name, version));
            return this;
        }

        public IHereConfigurationBuilder AddSearchService(string name = "search.", string version = "/v1")
        {
            _service.AddScoped<ISearchService>(c => new SearchService(HereConfiguration, name, version));
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
