using System.Net;

namespace ShoppingBuddy.BLL.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpResponseException(string? message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}