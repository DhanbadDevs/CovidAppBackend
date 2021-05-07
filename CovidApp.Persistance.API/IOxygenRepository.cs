using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance.API
{
    public interface IOxygenRepository
    {
        Task<IList<OxygenModel>> GetOxygens();
        Task<OxygenModel> AddOxygen(OxygenModel oxygenModel);
        
    }
}
