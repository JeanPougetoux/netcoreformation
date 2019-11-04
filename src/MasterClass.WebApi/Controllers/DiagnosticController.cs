using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterClass.Core;
using MasterClass.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MasterClass.WebApi.Controllers
{

    [Route("api/_system")]
    public class DiagnosticController : ControllerBase
    {
        //private readonly IApplicationRequestContext _requestContext;
        private readonly DiagnosticOptions _options;

        //public DiagnosticController(IApplicationRequestContext requestContext) => _requestContext = requestContext;

        public DiagnosticController(IOptionsMonitor<DiagnosticOptions> options)
        {
            _options = options.CurrentValue;
        }
        [HttpGet, HttpHead, Route("healthcheck")]
        public IActionResult HealthCheck()
        {
            //ControllerContext.HttpContext.Response.Headers.Add("X-Guid2", _requestContext.Id.ToString());
            return Ok(_options.HealthCheckContent);
        }
    }
}
