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
    public class MasterDelegate : IMasterDelegate
    {
        readonly IMasterService masterService;
        public MasterDelegate(IMasterService masterService)
        {
            this.masterService = masterService;
        }
        public async Task<Tuple<ServerResponse<CityModel>>> AddCity(CityModel cityModel)
        {
            var city = await masterService.AddCity(cityModel);
            return Tuple.Create(new ServerResponse<CityModel> { Message = Messages.OperationSuccessful, Payload = city.Item1 });
        }

        public async Task<ServerResponse<IList<CityModel>>> GetCities()
        {
            var result = await masterService.GetCities();
            if (result == null)
                return new ServerResponse<IList<CityModel>> { Message = Messages.NoCityFound };
            else
                return new ServerResponse<IList<CityModel>> { Message = Messages.OperationSuccessful, Payload = result };

        }
    }
}
