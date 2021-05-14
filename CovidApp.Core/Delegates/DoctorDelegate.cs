using CovidApp.Common.Constants;
using CovidApp.Core.API.Delegates;
using CovidApp.Core.API.Services;
using CovidApp.Core.Services;
using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Delegates
{
    public class DoctorDelegate : IDoctorDelegate
    {
        readonly IDoctorService doctorService;

        public DoctorDelegate(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public async Task<ServerResponse<DoctorModel>> AddDoctor(DoctorModel doctorModel)
        {
            if (doctorModel == null || String.IsNullOrWhiteSpace(doctorModel.DoctorName) || String.IsNullOrWhiteSpace(doctorModel.Medium) 
                || doctorModel.LocationId == 0 || doctorModel.CityId == 0 || doctorModel.CreatedOn == null)
                return new ServerResponse<DoctorModel> { Message = Messages.InvalidInput };

            var result = await doctorService.AddDoctor(doctorModel);

            if (result == null)
                return new ServerResponse<DoctorModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<DoctorModel> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<DoctorModel>>> GetDoctors(int cityId)
        {
            var result = await doctorService.GetDoctors(cityId);

            if (result == null)
                return new ServerResponse<IList<DoctorModel>> { Message = Messages.NoDoctorsFound };
            else
                return new ServerResponse<IList<DoctorModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
