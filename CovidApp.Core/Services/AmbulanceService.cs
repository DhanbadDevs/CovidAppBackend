using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;

namespace CovidApp.Core.Services
{
    public class AmbulanceService : IAmbulanceService
    {
        readonly IAmbulanceRepository ambulanceRepository;

        public AmbulanceService(IAmbulanceRepository ambulanceRepository)
        {
            this.ambulanceRepository = ambulanceRepository;
        }

        public async Task<Tuple<AmbulanceModel>> AddAmbulance(AmbulanceModel ambulanceModel)
        {
            return await ambulanceRepository.AddAmbulance(ambulanceModel);
        }

        public async Task<IList<AmbulanceModel>> GetAmbulances()
        {
            return await ambulanceRepository.GetAmbulances();
        }
    }
}
