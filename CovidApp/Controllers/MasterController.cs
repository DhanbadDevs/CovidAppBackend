using CovidApp.Core.API.Delegates;
using CovidApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CovidApp.Controllers
{
    [Route("api/master")]
    public class MasterController:Controller
    {
        readonly IMasterDelegate masterDelegate;
        readonly ILogger<MasterController> logger;
        public MasterController(IMasterDelegate masterDelegate,ILogger<MasterController> logger)
        {
            this.masterDelegate = masterDelegate;
            this.logger = logger;
            this.logger.LogDebug(1, "NLog injected into MasterController");
        }
        
        [HttpGet("city")]
        public async Task<IActionResult> GetMaster()
        {
            var response = await masterDelegate.GetCities();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityModel cityModel)
        {
            var response = await masterDelegate.AddCity(cityModel);

            return StatusCode(StatusCodes.Status201Created, response.Item1);

        }

    }
}
