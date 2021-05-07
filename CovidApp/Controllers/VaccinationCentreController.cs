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
    [Route("api/vaccinationcentre")]
    public class VaccinationCentreController : Controller
    {
        readonly IVaccinationCentreDelegate vaccinationCentreDelegate;
        readonly ILogger<VaccinationCentreController> _logger;
        public VaccinationCentreController(IVaccinationCentreDelegate VaccinationCentreDelegate, ILogger<VaccinationCentreController> logger)
        {
            _logger = logger;
            this.vaccinationCentreDelegate = VaccinationCentreDelegate;
            _logger.LogDebug(1, "NLog injected into VaccineController");
        }

        [HttpGet]
        public async Task<IActionResult> GetVaccinationCentres()
        {
            var response = await vaccinationCentreDelegate.GetVaccinationCentre();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] VaccinationCentreModel vaccinationCentreModel)
        {
            var response = await vaccinationCentreDelegate.AddVaccinationCentre(vaccinationCentreModel);
            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
