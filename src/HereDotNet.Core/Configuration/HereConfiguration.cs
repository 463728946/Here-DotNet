using RestSharp;
using System;

namespace HereDotNet.Core.Configuration
{
    
    public class HereConfiguration 
    {        
        internal IRestClient RestClient { get; set; }
        public string Shems { get; set; } = "https://";
        public string Domain { get; set; } = "hereapi.com";

        internal AuthType AuthType { get; set; } = AuthType.ApiKey;

        internal string AuthValue { get; set; }

        public HereConfiguration()
        {                             
            RestClient = new RestClient();
        }

        public HereConfiguration(string apiKey) : this()
        {
            UseApiKey(apiKey);
        }



        public void UseApiKey(string apikey)
        {
            AuthType = AuthType.ApiKey;
            AuthValue = apikey;
        }

        public void UseJwt(string token)
        {
            AuthType = AuthType.Jwt;
            AuthValue = token;
        }

        public void UseUserPassword(string user, string password)
        {
            throw new Exception("next version");
        }

    }

    public enum AuthType
    {
        Jwt,
        ApiKey
    }
}
