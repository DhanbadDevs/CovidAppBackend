using CovidApp.Core.API.Delegates;
using CovidApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp.Controllers
{
    [ApiController]
    [Route("api/oxygen")]
    public class OxygenController:Controller
    {
        readonly IOxygenDelegate oxygenDelegate;
        readonly ILogger<OxygenController> _logger;
        public OxygenController(IOxygenDelegate oxygenDelegate, ILogger<OxygenController> logger)
        {
            _logger = logger;
            this.oxygenDelegate = oxygenDelegate;
            _logger.LogDebug(1, "NLog injected into OxygenController");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOxygen([FromQuery] int cityId)
        {
            var response = await oxygenDelegate.GetAllOxygen(cityId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddOxygen([FromBody] OxygenModel oxygenModel)
        {
            var response = await oxygenDelegate.AddOxygen(oxygenModel);
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
