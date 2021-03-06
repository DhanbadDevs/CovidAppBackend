using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Delegates
{
    public interface IOxygenDelegate
    {
        Task<ServerResponse<IList<OxygenModel>>> GetAllOxygen(int cityId);
        Task<ServerResponse<OxygenModel>> AddOxygen(OxygenModel oxygenModel);
    }
}
