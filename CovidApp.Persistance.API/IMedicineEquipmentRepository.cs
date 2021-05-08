using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance.API
{
    public interface IMedicineEquipmentRepository
    {
        Task<IList<MedicineEquipmentModel>> GetMedicineEquipmentShop(int cityId, int medicineEquippmentId);
        Task<MedicineEquipmentModel> AddMedicineEquipmentShop(MedicineEquipmentModel medicineEquipmentModel);
        Task<IList<MedicineEquipmentMasterModel>> GetAllMedicines();
        Task<MedicineEquipmentMasterModel> AddMedicineEquipment(MedicineEquipmentMasterModel medicineEquipmentMasterModel);
    }
}
