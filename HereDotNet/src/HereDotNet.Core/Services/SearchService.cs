using HereDotNet.Core.Configuration;
using HereDotNet.Core.Request;
using HereDotNet.Core.Response;
using System.Threading.Tasks;


namespace HereDotNet.Core.Services
{
    public interface ISearchService : IHereService
    {
        Task<IResponse<GeocodeRequestResponse>> SearchAsync(GeocodeRequest hereRequest);
        Task<IResponse<DiscoverRequestReponse>> SearchAsync(DiscoverRequest hereRequest);
        Task<IResponse<AutoSuggestRequestResponse>> SearchAsync(AutoSuggestRequest hereRequest);
        Task<IResponse<AutocompleteRequestResponse>> SearchAsync(AutocompleteRequest hereRequest);
        Task<IResponse<ReverseGeocodeRequestResponse>> SearchAsync(ReverseGeocodeRequest hereRequest);
        Task<IResponse<BrowseRequestResponse>> SearchAsync(BrowseRequest hereRequest);

    }
    public class SearchService : ISearchService
    {
        public string ServiceName { get; set; }
        public string Version { get; set; }

        private readonly BaseService _service;

        public SearchService(IHereConfiguration hereConfiguration, string name, string version)
        {
            ServiceName = name;
            Version = version;
            _service = new BaseService(hereConfiguration, this);
        }



        public async Task<IResponse<GeocodeRequestResponse>> SearchAsync(GeocodeRequest hereRequest) 
            => await _service.HandleAsync<GeocodeRequest, GeocodeRequestResponse>(hereRequest);
       

        public async Task<IResponse<DiscoverRequestReponse>> SearchAsync(DiscoverRequest hereRequest)
            => await _service.HandleAsync<DiscoverRequest, DiscoverRequestReponse>(hereRequest);
    

        public async Task<IResponse<AutoSuggestRequestResponse>> SearchAsync(AutoSuggestRequest hereRequest)
            => await _service.HandleAsync<AutoSuggestRequest, AutoSuggestRequestResponse>(hereRequest);
      
        public async Task<IResponse<AutocompleteRequestResponse>> SearchAsync(AutocompleteRequest hereRequest)
            => await _service.HandleAsync<AutocompleteRequest, AutocompleteRequestResponse>(hereRequest);
      

        public async Task<IResponse<ReverseGeocodeRequestResponse>> SearchAsync(ReverseGeocodeRequest hereRequest)
            => await _service.HandleAsync<ReverseGeocodeRequest, ReverseGeocodeRequestResponse>(hereRequest);
     

        public async Task<IResponse<BrowseRequestResponse>> SearchAsync(BrowseRequest hereRequest)        
             => await _service.HandleAsync<BrowseRequest, BrowseRequestResponse>(hereRequest);
     
    }
}
