using CoreLibrary;
using MasterClass.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterClass.WebApi.Controllers
{
    [ApiController]
    [Route("api/_system")]
    public class DiagnosticController : ControllerBase
    {
        private readonly DiagnosticOptions _options;

        public DiagnosticController(IOptionsMonitor<DiagnosticOptions> options)
        {
            _options = options.CurrentValue;
        }

        [HttpGet, HttpHead, Route("healthcheck")]
        public IActionResult HealthCheck() => Ok(_options.HealthCheckContent);
    }
}
