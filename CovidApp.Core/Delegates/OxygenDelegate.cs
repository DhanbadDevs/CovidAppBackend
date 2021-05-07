using CovidApp.Core.API.Delegates;
using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Delegates
{
    public class OxygenDelegate : IOxygenDelegate
    {
        public Task<ServerResponse<OxygenModel>> AddOxygen(OxygenModel oxygenModel)
        {
            throw new NotImplementedException();
        }

        public Task<ServerResponse<IList<OxygenModel>>> GetOxygen()
        {
            throw new NotImplementedException();
        }
    }
}
