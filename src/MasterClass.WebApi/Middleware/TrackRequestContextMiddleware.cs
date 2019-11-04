using System.Threading.Tasks;
using MasterClass.WebApi.Middleware.ApplicationRequestContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

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
            context.Response.Headers.Add("X-Guid", requestContext.Id.ToString());
            await _next(context);
        }
    }
}