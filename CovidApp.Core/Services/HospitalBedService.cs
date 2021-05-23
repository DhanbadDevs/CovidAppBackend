using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class HospitalBedService : IHospitalBedService
    {
        readonly IHospitalBedRepository hospitalBedRepository;

        public HospitalBedService(IHospitalBedRepository hospitalBedRepository)
        {
            this.hospitalBedRepository = hospitalBedRepository;
        }

        public async Task<HospitalBedModel> AddOrUpdateHospitalBed(HospitalBedModel hospitalBedModel)
        {
            hospitalBedModel.CreatedOn = DateTime.UtcNow;
            hospitalBedModel.UpdatedOn = DateTime.UtcNow;
            return await hospitalBedRepository.AddOrUpdateHospitalBed(hospitalBedModel);
        }

        public async Task<IList<HospitalBedModel>> GetHospitalBeds( int cityId)
        {
            return await hospitalBedRepository.GetHospitalBeds(cityId);
        }
    }
}
