using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Services
{
    public interface IMasterService
    {
        Task<IList<CityModel>> GetCities();
        Task<CityModel> AddCity(CityModel cityModel);
        Task<IList<LocationModel>> GetLocations(long cityId);
        Task<LocationModel> AddLocation(LocationModel locationModel);
    }
}
