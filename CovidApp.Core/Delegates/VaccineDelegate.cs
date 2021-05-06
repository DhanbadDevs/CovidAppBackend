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
    public class VaccineDelegate : IVaccineDelegate
    {
        readonly IVaccineService vaccineService;

        public VaccineDelegate(IVaccineService vaccineService)
        {
            this.vaccineService = vaccineService;
        }

        public async Task<ServerResponse<IList<VaccineModel>>> GetVaccine()
        {
            var result = await vaccineService.GetVaccine();

            if (result == null)
                return new ServerResponse<IList<VaccineModel>> { Message = Messages.NoVaccinationCentreFound };
            else
                return new ServerResponse<IList<VaccineModel>> { Message = Messages.OperationSuccessful, Payload = result };
           
        }
    }
}
