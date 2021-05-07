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
        Task<Tuple<CityModel>> AddCity(CityModel cityModel);
    }
}
