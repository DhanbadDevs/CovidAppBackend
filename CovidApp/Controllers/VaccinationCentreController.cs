using CovidApp.Core.API.Delegates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp.Controllers
{
    [Route("api/vaccine")]
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
    }
}
