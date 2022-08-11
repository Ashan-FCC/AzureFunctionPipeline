using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlockchainLabs.Common.Authorization.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Blacksmith.Admin.Api
{
    public class ProxyFunction
    {

        private readonly IAccessTokenProvider _accessTokenProvider;
        public ProxyFunction(IAccessTokenProvider accessTokenProvider)
        {
            _accessTokenProvider = accessTokenProvider;
        }
    
        [FunctionName(nameof(Proxy))]
        public async Task<IActionResult> Proxy(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), nameof(HttpMethods.Post), nameof(HttpMethods.Patch), Route = "{*test}")]
            HttpRequest req, ILogger log)
        {
            var principal = _accessTokenProvider.GetAccessToken(req);
            var route = req.Path.ToString();
            var results = route.Split('/');

            var proxyPrefix = results[0];
            var api = results[1];
            principal.Principal.Claims.
            
            
            
                
            var method = req.Method;
            Console.WriteLine($"{method} - {route}");
            Console.WriteLine(string.Join(',', results));
            return new OkObjectResult(route);
        }
    }
}