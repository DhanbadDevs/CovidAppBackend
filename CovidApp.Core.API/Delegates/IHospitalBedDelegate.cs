using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Delegates
{
    public interface IHospitalBedDelegate
    {
        Task<ServerResponse<IList<HospitalBedModel>>> GetHospitalBeds(int cityId);
        Task<ServerResponse<HospitalBedModel>> AddOrUpdateHospitalBed(HospitalBedModel hospitalBedModel);
    }
}
