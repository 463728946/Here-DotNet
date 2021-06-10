using HereDotNet.Core.Configuration;
using HereDotNet.Core.Request;
using HereDotNet.Core.Response;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace HereDotNet.Core.Services
{
    public abstract class BaseService
    {
        private readonly HereConfiguration _cfg;       
        private readonly string _serviceName;
        private readonly string _version;

        public BaseService(HereConfiguration hereConfiguration, string name , string version)
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
                    break;
            }
        }

      
        public async Task<IResponse<TResponse>> HandleAsync<TRequest, TResponse>(TRequest hereRequest) where TRequest : IRequest
        {
            _cfg.RestClient.BaseUrl = new Uri($"{_cfg.Shems}{hereRequest.Root}{_serviceName}{_cfg.Domain}{_version}");

            var request = GetRequest(hereRequest);

            var result = await _cfg.RestClient.ExecuteAsync<TResponse>(request);
            return new DefaultResponse<TResponse>
            {
                Status = result.StatusDescription,
                IsSuccessful = result.IsSuccessful,
                ErrorMessage = result.ErrorMessage,
                StatusCode = result.StatusCode,
                Data = result.Data,
            };

        }

        private RestRequest GetRequest<TRequest>(TRequest hereRequest) where TRequest : IRequest
        {
            var method = Enum.Parse<Method>(hereRequest.Method);
            var request = new RestRequest(method)
            {
                Resource = hereRequest.Endpoint
            };
            var dic = new Dictionary<string, object>();
            var props = hereRequest.GetType().GetProperties();
            foreach (var prop in props)
            {
                var value = prop.GetValue(hereRequest);
                var attr = (DescriptionAttribute[])prop.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attr.Length == 1 && value != null)
                {
                    var type = value.GetType();

                    if (type.IsArray)
                    {
                        var items = (string[])value;
                        for (int i = 0; i < items.Length; i++)
                        {
                            var key = string.Format(attr[0].Description, i);
                            if (method == Method.GET)
                            {
                                request.AddParameter(key, items[i]);
                            }
                            else
                            {
                                dic.Add(key, items[i]);
                            }
                        }

                    }
                    else
                    {
                        if (method == Method.GET)
                        {
                            request.AddParameter(attr[0].Description, value);
                        }
                        else
                        {
                            dic.Add(attr[0].Description, value);
                        }
                    }
                }
            }
            if (dic.Count > 0)
            {
                var body = JsonConvert.SerializeObject(dic);
                request.AddJsonBody(body);
            }

            return request;
        }

    }


}
