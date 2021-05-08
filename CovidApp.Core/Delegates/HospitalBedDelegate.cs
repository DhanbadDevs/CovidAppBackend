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
    public class HospitalBedDelegate : IHospitalBedDelegate
    {
        readonly IHospitalBedService hospitalBedService;

        public HospitalBedDelegate(IHospitalBedService hospitalBedService)
        {
            this.hospitalBedService = hospitalBedService;
        }

        public Task<ServerResponse<IList<HospitalBedModel>>> AddOrUpdateHospitalBed(HospitalBedModel hospitalBedModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ServerResponse<IList<HospitalBedModel>>> GetHospitalBeds(string bedType)
        {
            var result = await hospitalBedService.GetHospitalBeds(bedType);

            if (result == null)
                return new ServerResponse<IList<HospitalBedModel>> { Message = Messages.NoHospitalBedsFound };
            else
                return new ServerResponse<IList<HospitalBedModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
