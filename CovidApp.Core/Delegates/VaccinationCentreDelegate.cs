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
    public class VaccinationCentreDelegate : IVaccinationCentreDelegate
    {
        readonly IVaccinationCentreService vaccinationCentreService;

        public VaccinationCentreDelegate(IVaccinationCentreService vaccinationCentreService)
        {
            this.vaccinationCentreService = vaccinationCentreService;
        }

        public async Task<ServerResponse<VaccinationCentreModel>> AddVaccinationCentre(VaccinationCentreModel vaccinationCentreModel)
        {
            if (vaccinationCentreModel == null || vaccinationCentreModel.LocationId == 0 || vaccinationCentreModel.CityId == 0
                || vaccinationCentreModel.Date == null || vaccinationCentreModel.CreatedOn == null)
                return new ServerResponse<VaccinationCentreModel> { Message = Messages.InvalidInput };

            var result = await vaccinationCentreService.AddVaccinationCentre(vaccinationCentreModel);

            if (result == null)
                return new ServerResponse<VaccinationCentreModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<VaccinationCentreModel> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<VaccinationCentreModel>>> GetVaccinationCentre(int cityId)
        {
            var result = await vaccinationCentreService.GetVaccinationCentre(cityId);

            if (result == null)
                return new ServerResponse<IList<VaccinationCentreModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<VaccinationCentreModel>> { Message = Messages.NoHospitalBedsFound };
            else
                return new ServerResponse<IList<VaccinationCentreModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
