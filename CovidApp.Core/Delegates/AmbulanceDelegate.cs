using System;
using System.Collections.Generic;
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

        public async Task<Tuple<ServerResponse<AmbulanceModel>>> AddAmbulance(AmbulanceModel ambulanceModel)
        {
            var ambulance = await ambulanceService.AddAmbulance(ambulanceModel);
            return Tuple.Create(new ServerResponse<AmbulanceModel> { Message = Messages.OperationSuccessful,Payload=ambulance });
        }

        public async Task<ServerResponse<IList<AmbulanceModel>>> GetAmbulances()
        {
            var result = await ambulanceService.GetAmbulances();
            if (result == null)
                return new ServerResponse<IList<AmbulanceModel>> { Message = Messages.NoAmbulanceFound };
            else
                return new ServerResponse<IList<AmbulanceModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
