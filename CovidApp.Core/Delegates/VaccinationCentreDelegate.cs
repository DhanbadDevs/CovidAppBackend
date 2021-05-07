using CovidApp.Common.Constants;
using CovidApp.Core.API.Delegates;
using CovidApp.Core.API.Services;
using CovidApp.Model;
using System;
using System.Collections.Generic;
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

        public async Task<ServerResponse<IList<VaccinationCentreModel>>> GetVaccinationCentre()
        {
            var result = await vaccinationCentreService.GetVaccinationCentre();

            if (result == null)
                return new ServerResponse<IList<VaccinationCentreModel>> { Message = Messages.NoVaccinationCentreFound };
            else
                return new ServerResponse<IList<VaccinationCentreModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
