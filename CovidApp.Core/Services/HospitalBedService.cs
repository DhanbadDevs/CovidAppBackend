using CovidApp.Common.Enums;
using CovidApp.Core.API.Services;
using CovidApp.Integration.API.AmritVahini;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<HospitalBedModel>> GetHospitalBeds(int cityId)
        {
            return await hospitalBedRepository.GetHospitalBeds(cityId);
        }
    }

}
