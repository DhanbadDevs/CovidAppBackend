using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class VaccinationCentreService : IVaccinationCentreService
    {
        readonly IVaccinationCentreRepository vaccinationCentreRepository;

        public VaccinationCentreService(IVaccinationCentreRepository vaccinationCentreRepository)
        {
            this.vaccinationCentreRepository = vaccinationCentreRepository;
        }

        public async Task<VaccinationCentreModel> AddVaccinationCentre(VaccinationCentreModel vaccinationCentreModel)
        {
            return await vaccinationCentreRepository.AddVaccinationCentre(vaccinationCentreModel);
        }

        public async Task<IList<VaccinationCentreModel>> GetVaccinationCentre()
        {
            return await vaccinationCentreRepository.GetVaccinationCentre();
        }
    }
}
