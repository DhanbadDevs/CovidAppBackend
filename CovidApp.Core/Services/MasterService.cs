using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class MasterService : IMasterService
    {
        readonly IMasterRepository masterRepository;

        public MasterService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public async Task<Tuple<CityModel>> AddCity(CityModel cityModel)
        {
            return await masterRepository.AddCity(cityModel);
        }

        public async Task<LocationModel> AddLocation(LocationModel locationModel)
        {
            return await masterRepository.AddLocation(locationModel);
        }

        public async Task<IList<CityModel>> GetCities()
        {
            return await masterRepository.GetCities();    
        }

        public async Task<IList<LocationModel>> GetLocations(long cityId, long locationTypeId)
        {
            return await masterRepository.GetLocations(cityId, locationTypeId);
        }
    }
}
