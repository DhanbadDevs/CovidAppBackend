using CovidApp.Common.Constants;
using CovidApp.Core.API.Delegates;
using CovidApp.Core.API.Services;
using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Delegates
{
    public class MedicineEquipmentDelegate : IMedicineEquipmentDelegate
    {
        readonly IMedicineEquipmentService medicineEquipmentService;

        public MedicineEquipmentDelegate(IMedicineEquipmentService medicineEquipmentService)
        {
            this.medicineEquipmentService = medicineEquipmentService;
        }

        public async Task<ServerResponse<MedicineEquipmentMasterModel>> AddMedicineEquipment(MedicineEquipmentMasterModel medicineEquipmentMasterModel)
        {
            if (medicineEquipmentMasterModel == null || String.IsNullOrWhiteSpace(medicineEquipmentMasterModel.MedicineEquipmentName))
                return new ServerResponse<MedicineEquipmentMasterModel> { Message = Messages.InvalidInput };

            var result = await medicineEquipmentService.AddMedicineEquipment(medicineEquipmentMasterModel);

            if (result == null)
                return new ServerResponse<MedicineEquipmentMasterModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<MedicineEquipmentMasterModel> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<MedicineEquipmentModel>> AddMedicineEquipmentShop(MedicineEquipmentModel medicineEquipmentModel)
        {
            if (medicineEquipmentModel == null || medicineEquipmentModel.LocationId == 0 || medicineEquipmentModel.CityId == 0)
                return new ServerResponse<MedicineEquipmentModel> { Message = Messages.InvalidInput };

            var result = await medicineEquipmentService.AddMedicineEquipmentShop(medicineEquipmentModel);

            if (result == null)
                return new ServerResponse<MedicineEquipmentModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<MedicineEquipmentModel> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<MedicineEquipmentMasterModel>>> GetAllMedicines()
        {
            var result = await medicineEquipmentService.GetAllMedicines();

            if (result == null)
                return new ServerResponse<IList<MedicineEquipmentMasterModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<MedicineEquipmentMasterModel>> { Message = Messages.NoMedicinesEquipmentsFound };
            else
                return new ServerResponse<IList<MedicineEquipmentMasterModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<MedicineEquipmentModel>>> GetMedicineEquipmentShop(int cityId, int medicineEquippmentId)
        {
            if(cityId == 0 || medicineEquippmentId == 0)
                return new ServerResponse<IList<MedicineEquipmentModel>> { Message = Messages.InvalidInput };

            var result = await medicineEquipmentService.GetMedicineEquipmentShop(cityId, medicineEquippmentId);

            if (result == null)
                return new ServerResponse<IList<MedicineEquipmentModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<MedicineEquipmentModel>> { Message = Messages.NoMedicalShopsFound };
            else
                return new ServerResponse<IList<MedicineEquipmentModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
