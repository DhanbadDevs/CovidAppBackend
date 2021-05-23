using CovidApp.Core.API.Delegates;
using CovidApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CovidApp.Controllers
{
    [ApiController]
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

        [HttpPost("city")]
        public async Task<IActionResult> AddCity([FromBody] CityModel cityModel)
        {
            var response = await masterDelegate.AddCity(cityModel);

            return StatusCode(StatusCodes.Status201Created, response);

        }

        [HttpGet("location")]
        public async Task<IActionResult> GetLocations([Required]long cityId, long locationTypeId)
        {
            var response = await masterDelegate.GetLocations(cityId, locationTypeId);
            return Ok(response);
        }

        [HttpPost("location")]
        public async Task<IActionResult> AddLocation([FromBody] LocationModel locationModel)
        {
            var response = await masterDelegate.AddLocation(locationModel);

            return StatusCode(StatusCodes.Status201Created, response);

        }

        [HttpGet("helplines")]
        public async Task<IActionResult> GetHelplines([Required] long cityId)
        {
            var response = await masterDelegate.GetHelpline(cityId);
            return Ok(response);
        }

        [HttpPost("helplines")]
        public async Task<IActionResult> AddHelpline([FromBody] HelplineModel helplineModel)
        {
            var response = await masterDelegate.AddHelpline(helplineModel);
            return StatusCode(StatusCodes.Status201Created, response);

        }

        [HttpGet("feedbacks")]
        public async Task<IActionResult> GetFeedback( long cityId)
        {
            var response = await masterDelegate.GetFeedback(cityId);
            return Ok(response);
        }

        [HttpPost("feedbacks")]
        public async Task<IActionResult> AddFeedback([FromBody] FeedbackModel feedbackModel)
        {
            var response = await masterDelegate.AddFeedback(feedbackModel);
            return StatusCode(StatusCodes.Status201Created, response);

        }

        [HttpGet("volunteers")]
        public async Task<IActionResult> GetVolunteer()
        {
            var response = await masterDelegate.GetVolunteer();
            return Ok(response);
        }

        [HttpPost("volunteers")]
        public async Task<IActionResult> AddVolunteer([FromBody] VolunteerModel VolunteerModel)
        {
            var response = await masterDelegate.AddVolunteer(VolunteerModel);
            return StatusCode(StatusCodes.Status201Created, response);

        }
    }
}
