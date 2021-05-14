using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class OxygenService : IOxygenService
    {
        readonly IOxygenRepository oxygenRepository;
        public OxygenService(IOxygenRepository oxygenRepository)
        {
            this.oxygenRepository = oxygenRepository;
        }
        public async Task<OxygenModel> AddOxygen(OxygenModel oxygenModel)
        {
            return await oxygenRepository.AddOxygen(oxygenModel);
        }

        public async Task<IList<OxygenModel>> GetOxygens(int cityId)
        {
            return await oxygenRepository.GetOxygens(cityId);
        }
    }
}
