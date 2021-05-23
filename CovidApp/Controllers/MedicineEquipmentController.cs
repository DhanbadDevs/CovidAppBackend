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
    [Route("api/medicines")]
    public class MedicineEquipmentController : Controller
    {
        readonly IMedicineEquipmentDelegate medicineEquipmentDelegate;
        readonly ILogger<MedicineEquipmentController> _logger;
        public MedicineEquipmentController(IMedicineEquipmentDelegate medicineEquipmentDelegate, ILogger<MedicineEquipmentController> logger)
        {
            _logger = logger;
            this.medicineEquipmentDelegate = medicineEquipmentDelegate;
            _logger.LogDebug(1, "NLog injected into MedicineEquipmentController");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicines()
        {
            var response = await medicineEquipmentDelegate.GetAllMedicines();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicineEquipment([FromBody] MedicineEquipmentMasterModel medicineEquipmentMasterModel)
        {
            var response = await medicineEquipmentDelegate.AddMedicineEquipment(medicineEquipmentMasterModel);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("medicalshops")]
        public async Task<IActionResult> GetMedicineEquipmentShop([FromQuery]int cityId, [FromQuery]int medicineEquippmentId)
        {
            var response = await medicineEquipmentDelegate.GetMedicineEquipmentShop(cityId, medicineEquippmentId);
            return Ok(response);
        }

        [HttpPost("medicalshop")]
        public async Task<IActionResult> AddMedicineEquipmentShop([FromBody] MedicineEquipmentModel medicineEquipmentModel)
        {
            var response = await medicineEquipmentDelegate.AddMedicineEquipmentShop(medicineEquipmentModel);
            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
