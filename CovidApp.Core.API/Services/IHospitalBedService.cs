using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Services
{
    public interface IHospitalBedService
    {
        Task<IList<HospitalBedModel>> GetHospitalBeds(string bedType, int cityId);
        Task<HospitalBedModel> AddOrUpdateHospitalBed(HospitalBedModel hospitalBedModel);
    }
}
