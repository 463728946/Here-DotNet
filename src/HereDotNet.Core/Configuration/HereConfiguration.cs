using RestSharp;


namespace HereDotNet.Core.Configuration
{

    public interface IHereConfiguration
    {       
        string Shems { get; set; }
        string Domain { get; set; } 
        AuthType AuthType { get; set; }
        string AuthValue { get; set; }
        IRestClient RestClient { get; set; }
       
    }

    public class HereConfiguration : IHereConfiguration
    {        
        public IRestClient RestClient { get; set; }
        public string Shems { get; set; } 
        public string Domain { get; set; } 

        public AuthType AuthType { get; set; }

        public string AuthValue { get; set; }

        public HereConfiguration(string shems = "https://", string domain = "hereapi.com")
        {
            Shems = shems;
            Domain = domain;
            RestClient = new RestClient();
        }

    }

    public enum AuthType
    {
        Jwt,
        ApiKey
    }
}
