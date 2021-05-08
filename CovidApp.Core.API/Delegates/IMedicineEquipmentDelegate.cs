using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Delegates
{
    public interface IMedicineEquipmentDelegate
    {
        Task<ServerResponse<IList<MedicineEquipmentModel>>> GetMedicineEquipmentShop(int cityId, int medicineEquippmentId);
        Task<ServerResponse<MedicineEquipmentModel>> AddMedicineEquipmentShop(MedicineEquipmentModel medicineEquipmentModel);
        Task<ServerResponse<IList<MedicineEquipmentMasterModel>>> GetAllMedicines();
        Task<ServerResponse<MedicineEquipmentMasterModel>> AddMedicineEquipment(MedicineEquipmentMasterModel medicineEquipmentMasterModel);
    }
}
