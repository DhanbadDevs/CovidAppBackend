using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class MedicineEquipmentService : IMedicineEquipmentService
    {
        readonly IMedicineEquipmentRepository medicineEquipmentRepository;

        public MedicineEquipmentService(IMedicineEquipmentRepository medicineEquipmentRepository)
        {
            this.medicineEquipmentRepository = medicineEquipmentRepository;
        }

        public async Task<MedicineEquipmentMasterModel> AddMedicineEquipment(MedicineEquipmentMasterModel medicineEquipmentMasterModel)
        {
            medicineEquipmentMasterModel.CreatedOn = DateTime.UtcNow;
            medicineEquipmentMasterModel.UpdatedOn = DateTime.UtcNow;
            return await medicineEquipmentRepository.AddMedicineEquipment(medicineEquipmentMasterModel);
        }

        public async Task<MedicineEquipmentModel> AddMedicineEquipmentShop(MedicineEquipmentModel medicineEquipmentModel)
        {
            medicineEquipmentModel.CreatedOn = DateTime.UtcNow;
            medicineEquipmentModel.UpdatedOn = DateTime.UtcNow;
            return await medicineEquipmentRepository.AddMedicineEquipmentShop(medicineEquipmentModel);
        }

        public async Task<IList<MedicineEquipmentMasterModel>> GetAllMedicines()
        {
            return await medicineEquipmentRepository.GetAllMedicines();
        }

        public async Task<IList<MedicineEquipmentModel>> GetMedicineEquipmentShop(int cityId, int medicineEquippmentId)
        {
            return await medicineEquipmentRepository.GetMedicineEquipmentShop(cityId, medicineEquippmentId);
        }
    }
}
