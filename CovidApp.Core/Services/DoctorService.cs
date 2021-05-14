using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class DoctorService : IDoctorService
    {
        readonly IDoctorRepository doctorRepository;

        public DoctorService (IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task<DoctorModel> AddDoctor(DoctorModel doctorModel)
        {
            return await doctorRepository.AddDoctor(doctorModel);
        }

        public async Task<IList<DoctorModel>> GetDoctors(int cityId)
        {
            return await doctorRepository.GetDoctors(cityId);
        }
    }
}
