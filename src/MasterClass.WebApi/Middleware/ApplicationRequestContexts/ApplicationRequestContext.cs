using System;

namespace MasterClass.WebApi.Middleware.ApplicationRequestContexts
{
    public class ApplicationRequestContext : IApplicationRequestContext
    {
        public ApplicationRequestContext()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
    }
}