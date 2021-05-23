using CovidApp.Common.Constants;
using CovidApp.Core.API.Delegates;
using CovidApp.Core.API.Services;
using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CovidApp.Core.Delegates
{
    public class OxygenDelegate : IOxygenDelegate
    {
        readonly IOxygenService oxygenService;
        public OxygenDelegate(IOxygenService oxygenService){
            this.oxygenService = oxygenService;
        }
        public async Task<ServerResponse<OxygenModel>> AddOxygen(OxygenModel oxygenModel)
        {
            if (oxygenModel == null || oxygenModel.LocationId == 0 || oxygenModel.CityId == 0)
                return new ServerResponse<OxygenModel> { Message = Messages.InvalidInput };

            var result = await oxygenService.AddOxygen(oxygenModel);

            if (result == null)
                return new ServerResponse<OxygenModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<OxygenModel> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<OxygenModel>>> GetAllOxygen(int cityId)
        {
            if (cityId == 0 )
                return new ServerResponse<IList<OxygenModel>> { Message = Messages.InvalidInput };

            var result = await oxygenService.GetOxygens(cityId);

            if (result == null)
                return new ServerResponse<IList<OxygenModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<OxygenModel>> { Message = Messages.NoOxygenFound };
            else
                return new ServerResponse<IList<OxygenModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
