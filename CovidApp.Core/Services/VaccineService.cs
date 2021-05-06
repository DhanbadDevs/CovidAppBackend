using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class VaccineService : IVaccineService
    {
        readonly IVaccineRepository vaccineRepository;

        public VaccineService(IVaccineRepository vaccineRepository)
        {
            this.vaccineRepository = vaccineRepository;
        }

        public async Task<IList<VaccineModel>> GetVaccine()
        {
            return await vaccineRepository.GetVaccine();
            return null;
        }
    }
}
