using System.Net;

namespace PT.WebAPI.Model
{
    public class ErrorMessage
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
