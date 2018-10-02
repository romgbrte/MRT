/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MRT.Authentication_Authorization
{
    public class ChallengeResult : IHttpActionResult
    {
        public string LoginProvider { get; set; }

        public HttpRequestMessage Request { get; set; }

        public ChallengeResult(string loginProvider, ApiController apiController)
        {
            LoginProvider = loginProvider;
            Request = apiController.Request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            Request.GetOwinContext().Authentication.Challenge(LoginProvider);

            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                RequestMessage = Request
            };

            return Task.FromResult(response);
        }
    }
}
*/