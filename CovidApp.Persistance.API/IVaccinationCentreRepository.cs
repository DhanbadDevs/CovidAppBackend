using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CovidApp.Model;

namespace CovidApp.Persistance.API
{
    public interface IVaccinationCentreRepository
    {
        Task<IList<VaccinationCentreModel>> GetVaccinationCentre(int cityId);
        Task<VaccinationCentreModel> AddVaccinationCentre(VaccinationCentreModel vaccinationCentreModel);
    }
}
