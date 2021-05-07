using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Delegates
{
    public interface IMasterDelegate
    {
        Task<ServerResponse<IList<CityModel>>> GetCities();
        Task<ServerResponse<CityModel>> AddCity(CityModel cityModel);
        Task<ServerResponse<IList<LocationModel>>> GetLocations(long cityId);
        Task<ServerResponse<LocationModel>> AddLocation(LocationModel locationModel);
    }
}
