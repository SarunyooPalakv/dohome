using Dohome.Model;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Dohome.API
{
    internal class CustomExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            ResponseInfo<string> result = new ResponseInfo<string>();
            result.code = "999";
            result.message = "System Exception";

            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, result);

            context.Result = new ResponseMessageResult(response);

            return base.HandleAsync(context, cancellationToken);
        }

        public virtual bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }
}