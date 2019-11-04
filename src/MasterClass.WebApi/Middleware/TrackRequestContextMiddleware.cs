using MasterClass.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterClass.WebApi.Middleware
{
    public class TrackRequestContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TrackRequestContextMiddleware> _logger;

        public TrackRequestContextMiddleware(RequestDelegate next, ILogger<TrackRequestContextMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IApplicationRequestContext requestContext)
        {
            _logger.LogInformation($"X-Guid : {requestContext.Id}");
            await _next(context);
        }
    }
}
