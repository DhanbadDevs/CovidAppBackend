using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidApp.Core.API.Delegates;
using CovidApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CovidApp.Controllers
{
    [ApiController]
    [Route("api/ambulance")]
    public class AmbulanceController:Controller
    {
        readonly IAmbulanceDelegate ambulanceDelegate;
        readonly ILogger<AmbulanceController> _logger;

        public AmbulanceController(IAmbulanceDelegate ambulanceDelegate, ILogger<AmbulanceController> logger)
        {
            _logger = logger;
            this.ambulanceDelegate = ambulanceDelegate;
            _logger.LogDebug(1, "NLog injected into Ambulance Controller");
        }

        [HttpGet]
        public async Task<IActionResult> GetAmbulance([FromQuery] int cityId)
        {
            var response = await ambulanceDelegate.GetAmbulances(cityId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAmbulance([FromBody] AmbulanceModel ambulanceModel)
        {
            var response = await ambulanceDelegate.AddAmbulance(ambulanceModel);
            
                return StatusCode(StatusCodes.Status201Created, response);
           
        }
    }
}
