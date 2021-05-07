using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance
{
    public class OxygenRepository : IOxygenRepository
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
