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

        public async Task<AmbulanceModel> AddAmbulance(AmbulanceModel ambulanceModel)
        {
            ambulanceModel.CreatedOn = DateTime.UtcNow;
            ambulanceModel.UpdatedOn = DateTime.UtcNow;
            return await ambulanceRepository.AddAmbulance(ambulanceModel);
        }

        public async Task<IList<AmbulanceModel>> GetAmbulances(int cityId)
        {
            return await ambulanceRepository.GetAmbulances(cityId);
        }
    }
}
