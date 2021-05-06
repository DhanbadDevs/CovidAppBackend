using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Services
{
    public interface IVaccineService
    {
        Task<IList<VaccineModel>> GetVaccine();
    }
}
