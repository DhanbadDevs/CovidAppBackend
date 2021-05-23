using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance.API
{
    public interface IDoctorRepository
    {
        Task<IList<DoctorModel>> GetDoctors(int cityId);
        Task<DoctorModel> AddDoctor(DoctorModel doctorModel);
    }
}
