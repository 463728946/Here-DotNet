using System.Net;


namespace HereDotNet.Core.Response
{
    public class DefaultResponse<T> : IResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string Status { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }

    }
}
