using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance.API
{
    public interface IHospitalBedRepository
    {
        Task<IList<HospitalBedModel>> GetHospitalBeds(int cityId);
        Task<HospitalBedModel> AddOrUpdateHospitalBed(HospitalBedModel hospitalBedModel);
    }
}
