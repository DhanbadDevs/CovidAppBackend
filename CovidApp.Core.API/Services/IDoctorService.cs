using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Services
{
    public interface IDoctorService
    {
        Task<IList<DoctorModel>> GetDoctors(int cityId);
        Task<DoctorModel> AddDoctor(DoctorModel doctorModel);
    }
}
