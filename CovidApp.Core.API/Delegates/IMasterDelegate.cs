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
        Task<Tuple<ServerResponse<CityModel>>> AddCity(CityModel cityModel);

    }
}
