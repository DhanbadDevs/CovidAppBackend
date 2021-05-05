using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CovidApp.Model;

namespace CovidApp.Persistance.API
{
    public interface IVaccineRepository
    {
        Task<VaccineModel> GetVaccine();
    }
}
