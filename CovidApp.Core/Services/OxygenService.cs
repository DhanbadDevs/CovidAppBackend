using CovidApp.Core.API.Services;
using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class OxygenService : IOxygenService
    {
        public Task<OxygenModel> AddOxygen(OxygenModel oxygenModel)
        {
            throw new NotImplementedException();
        }

        public Task<IList<OxygenModel>> GetOxygens()
        {
            throw new NotImplementedException();
        }
    }
}
