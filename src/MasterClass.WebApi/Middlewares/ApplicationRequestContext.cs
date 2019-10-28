using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterClass.WebApi.Middlewares
{
    public class ApplicationRequestContext : IApplicationRequestContext
    {
        public Guid Id { get; }
        public ApplicationRequestContext()
        {
            Id = Guid.NewGuid();
        }
    }
}
