using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Delegates
{
    public interface IDoctorDelegate
    {
        Task<ServerResponse<IList<DoctorModel>>> GetDoctors(int cityId);
        Task<ServerResponse<DoctorModel>> AddDoctor(DoctorModel doctorModel);
    }
}
