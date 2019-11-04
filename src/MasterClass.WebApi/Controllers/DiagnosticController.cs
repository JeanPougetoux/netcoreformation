using MasterClass.Core;
using MasterClass.WebApi.Middleware.ApplicationRequestContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MasterClass.WebApi.Controllers
{
    [Route("api/_system")]
    public class DiagnosticController : ControllerBase
    {
        private readonly IApplicationRequestContext  _requestContext;
        private readonly DiagnosticOptions _options;

        public DiagnosticController(IApplicationRequestContext requestContext, IOptions<DiagnosticOptions> options)
        {
            _requestContext = requestContext;
            _options = options.Value;
        }

        [HttpGet, HttpHead, Route("healthcheck")]
        public IActionResult HealthCheck(){
            ControllerContext.HttpContext.Response.Headers.Add("X-Guid2", _requestContext.Id.ToString());
             return Ok(_options.HealthCheckContent);   
        }
        
    }
}