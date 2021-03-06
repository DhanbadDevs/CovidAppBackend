using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidApp.Common.Constants;
using CovidApp.Core.API.Delegates;
using CovidApp.Core.API.Services;
using CovidApp.Model;

namespace CovidApp.Core.Delegates
{
    public class AmbulanceDelegate : IAmbulanceDelegate
    {
        readonly IAmbulanceService ambulanceService;
        public AmbulanceDelegate(IAmbulanceService ambulanceService)
        {
            this.ambulanceService = ambulanceService;
        }

        public async Task<ServerResponse<AmbulanceModel>> AddAmbulance(AmbulanceModel ambulanceModel)
        {
            if (ambulanceModel == null || String.IsNullOrWhiteSpace(ambulanceModel.AmbulanceName) || ambulanceModel.CityId == 0)
                return new ServerResponse<AmbulanceModel> { Message = Messages.InvalidInput };
            var ambulance = await ambulanceService.AddAmbulance(ambulanceModel);

            if (ambulance == null)
                return new ServerResponse<AmbulanceModel> { Message = Messages.ErrorOccured };
            return new ServerResponse<AmbulanceModel> { Message = Messages.OperationSuccessful,Payload=ambulance };
        }

        public async Task<ServerResponse<IList<AmbulanceModel>>> GetAmbulances(int cityid)
        {
            var result = await ambulanceService.GetAmbulances(cityid);
            if (result == null)
                return new ServerResponse<IList<AmbulanceModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<AmbulanceModel>> { Message = Messages.NoAmbulanceFound };
            else
                return new ServerResponse<IList<AmbulanceModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
