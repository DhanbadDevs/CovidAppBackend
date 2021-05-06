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
    public class VaccineController : Controller
    {
        readonly IVaccineDelegate vaccineDelegate;
        readonly ILogger<VaccineController> _logger;
        public VaccineController(IVaccineDelegate vaccineDelegate, ILogger<VaccineController> logger)
        {
            _logger = logger;
            this.vaccineDelegate = vaccineDelegate;
            _logger.LogDebug(1, "NLog injected into VaccineController");
        }


        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> GetVaccines()
        {
            var response = await vaccineDelegate.GetVaccine();
            return Ok(response);
        }
    }
}
