﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterClass.WebApi.Middlewares
{
    public interface IApplicationRequestContext
    {
        Guid Id { get; }
    }
}
