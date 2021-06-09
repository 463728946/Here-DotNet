using HereDotNet.Core.Configuration;
using HereDotNet.Core.Request;
using HereDotNet.Core.Response;
using System.Threading.Tasks;

namespace HereDotNet.Core.Services
{
    public interface IRouteService: IHereService
    {
        Task<IResponse<FindSequenceRequestResponse>> FindsequenceAsync(FindSequenceRequest request);
    }


    public class RouteService : IRouteService
    {
        public string ServiceName { get; set; }
        public string Version { get; set; }
       
        private readonly BaseService _service;

        public RouteService(IHereConfiguration hereConfiguration,string name,string version) 
        {
            ServiceName = name;
            Version = version;

            _service = new BaseService(hereConfiguration, this);
        }

      

        public async Task<IResponse<FindSequenceRequestResponse>> FindsequenceAsync(FindSequenceRequest hereRequest)        
             => await _service.HandleAsync<FindSequenceRequest,FindSequenceRequestResponse>(hereRequest);
      




    }

}
