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
    [Route("api/doctors")]
    public class DoctorController : Controller
    {
        readonly IDoctorDelegate doctorDelegate;
        readonly ILogger<DoctorController> _logger;

        public DoctorController(IDoctorDelegate doctorDelegate, ILogger<DoctorController> logger)
        {
            _logger = logger;
            this.doctorDelegate = doctorDelegate;
            _logger.LogDebug(1, "NLog injected into DoctorController");
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors(int cityId)
        {
            var response = await doctorDelegate.GetDoctors(cityId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorModel doctorModel)
        {
            var response = await doctorDelegate.AddDoctor(doctorModel);

            return StatusCode(StatusCodes.Status201Created, response);

        }
    }
}
