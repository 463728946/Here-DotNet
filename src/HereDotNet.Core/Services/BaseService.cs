using HereDotNet.Core.Configuration;
using HereDotNet.Core.Request;
using HereDotNet.Core.Response;
using RestSharp;
using System;
using System.Threading.Tasks;
using HereDotNet.Core.Extensions;

namespace HereDotNet.Core.Services
{
    public abstract class BaseService
    {
        private readonly HereConfiguration _cfg;       
        private readonly string _serviceName;
        private readonly string _version;

        protected BaseService(HereConfiguration hereConfiguration, string name , string version)
        {
            _cfg = hereConfiguration;
            _serviceName = name;
            _version = version;
            switch (_cfg.AuthType)
            {
                case AuthType.Jwt:
                    _cfg.RestClient.AddDefaultHeader("token", $"Bearer { _cfg.AuthValue}");
                    break;
                case AuthType.ApiKey:
                    _cfg.RestClient.AddDefaultParameter("apikey", _cfg.AuthValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

      
        internal async Task<IResponse<TResponse>> HandleAsync<TRequest, TResponse>(TRequest hereRequest) where TRequest : IRequest
        {
            _cfg.RestClient.BaseUrl = new Uri($"{_cfg.Shems}{hereRequest.Root}{_serviceName}{_cfg.Domain}{_version}");
            var request = new RestRequest(hereRequest.Method) { Resource = hereRequest.Endpoint };
            foreach (var (key, value) in hereRequest.ToParameter())
            {
                request.AddParameter(key, value);
            }
            
            var result = await _cfg.RestClient
                .ExecuteAsync<TResponse>(request)
                .ConfigureAwait(false);

            return new DefaultResponse<TResponse>
            {
                Status = result.StatusDescription,
                IsSuccessful = result.IsSuccessful,
                ErrorMessage = result.ErrorMessage,
                StatusCode = result.StatusCode,
                Data = result.Data,
            };

        }
    }


}
