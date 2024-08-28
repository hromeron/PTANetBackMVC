using System.Net;

namespace PT.DockerWebAPI.Model
{
    public class ErrorMessage
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
