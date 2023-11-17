using System.Net;

namespace ShoppingBuddy.BLL.Exceptions
{
    public class NotFoundException : HttpResponseException
    {
        public NotFoundException(string? message) : base(message, HttpStatusCode.NotFound) { }
    }
}