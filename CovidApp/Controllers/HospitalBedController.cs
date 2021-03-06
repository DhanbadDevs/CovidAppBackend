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
    [Route("api/hospitalbeds")]
    public class HospitalBedController : Controller
    {
        readonly IHospitalBedDelegate hospitalBedDelegate;
        readonly ILogger<HospitalBedController> _logger;
        public HospitalBedController(IHospitalBedDelegate hospitalBedDelegate, ILogger<HospitalBedController> logger)
        {
            _logger = logger;
            this.hospitalBedDelegate = hospitalBedDelegate;
            _logger.LogDebug(1, "NLog injected into HospitalBedController");
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitalBeds([FromQuery] int cityId)
        {
            var response = await hospitalBedDelegate.GetHospitalBeds(cityId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateHospitalBed([FromBody] HospitalBedModel hospitalBedModel)
        {
            var response = await hospitalBedDelegate.AddOrUpdateHospitalBed(hospitalBedModel);
            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
