using System.Net;

namespace ShoppingBuddy.BLL.Exceptions
{
    public class BadRequestException : HttpResponseException
    {
        public BadRequestException(string? message) : base(message, HttpStatusCode.BadRequest) { }
    }
}