using HereDotNet.Core.Configuration;
using HereDotNet.Core.Request;
using HereDotNet.Core.Response;
using System.Threading.Tasks;


namespace HereDotNet.Core.Services
{
    public interface ISearchService 
    {
        Task<IResponse<GeocodeRequestResponse>> SearchAsync(GeocodeRequest hereRequest);
       /* Task<IResponse<DiscoverRequestReponse>> SearchAsync(DiscoverRequest hereRequest);
        Task<IResponse<AutoSuggestRequestResponse>> SearchAsync(AutoSuggestRequest hereRequest);
        Task<IResponse<AutocompleteRequestResponse>> SearchAsync(AutocompleteRequest hereRequest);
        Task<IResponse<ReverseGeocodeRequestResponse>> SearchAsync(ReverseGeocodeRequest hereRequest);
        Task<IResponse<BrowseRequestResponse>> SearchAsync(BrowseRequest hereRequest);*/

    }
    public class SearchService : BaseService, ISearchService
    {
             
        public SearchService(HereConfiguration hereConfiguration, string name = "search.", string version = "/v1"):base(hereConfiguration, name, version){ }

        public async Task<IResponse<GeocodeRequestResponse>> SearchAsync(GeocodeRequest hereRequest) 
            => await HandleAsync<GeocodeRequest, GeocodeRequestResponse>(hereRequest);
       
        /*
        public async Task<IResponse<DiscoverRequestReponse>> SearchAsync(DiscoverRequest hereRequest)
            => await HandleAsync<DiscoverRequest, DiscoverRequestReponse>(hereRequest);
    
        public async Task<IResponse<AutoSuggestRequestResponse>> SearchAsync(AutoSuggestRequest hereRequest)
            => await HandleAsync<AutoSuggestRequest, AutoSuggestRequestResponse>(hereRequest);
      
        public async Task<IResponse<AutocompleteRequestResponse>> SearchAsync(AutocompleteRequest hereRequest)
            => await HandleAsync<AutocompleteRequest, AutocompleteRequestResponse>(hereRequest);
      
        public async Task<IResponse<ReverseGeocodeRequestResponse>> SearchAsync(ReverseGeocodeRequest hereRequest)
            => await HandleAsync<ReverseGeocodeRequest, ReverseGeocodeRequestResponse>(hereRequest);
     
        public async Task<IResponse<BrowseRequestResponse>> SearchAsync(BrowseRequest hereRequest)        
             => await HandleAsync<BrowseRequest, BrowseRequestResponse>(hereRequest);
     */
    }
}
