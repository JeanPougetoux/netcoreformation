using System;

namespace MasterClass.WebApi.Middleware.ApplicationRequestContexts
{
    public interface IApplicationRequestContext
    {
        Guid Id { get; }
    }
}