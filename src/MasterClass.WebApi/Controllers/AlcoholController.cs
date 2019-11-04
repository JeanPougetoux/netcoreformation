using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterClass.WebApi.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterClass.WebApi.Controllers
{
    [Route("api/alcohol"), Authorize(Policy = Policies.REQUIRED_ALCOHOL_MAJORITY)]
    public class AlcoholController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}