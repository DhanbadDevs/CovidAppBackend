﻿using CovidApp.Common.Constants;
using CovidApp.Core.API.Delegates;
using CovidApp.Core.API.Services;
using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Delegates
{
    public class HospitalBedDelegate : IHospitalBedDelegate
    {
        readonly IHospitalBedService hospitalBedService;

        public HospitalBedDelegate(IHospitalBedService hospitalBedService)
        {
            this.hospitalBedService = hospitalBedService;
        }

        public async Task<ServerResponse<HospitalBedModel>> AddOrUpdateHospitalBed(HospitalBedModel hospitalBedModel)
        {
            if (hospitalBedModel == null || hospitalBedModel.LocationId == 0 || hospitalBedModel.CityId == 0
                || String.IsNullOrWhiteSpace(hospitalBedModel.BedType) || hospitalBedModel.CreatedOn == null
                || hospitalBedModel.City == null || hospitalBedModel.Location == null)
                return new ServerResponse<HospitalBedModel> { Message = Messages.InvalidInput };

            var result = await hospitalBedService.AddOrUpdateHospitalBed(hospitalBedModel);

            if (result == null)
                return new ServerResponse<HospitalBedModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<HospitalBedModel> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<HospitalBedModel>>> GetHospitalBeds(string bedType)
        {
            var result = await hospitalBedService.GetHospitalBeds(bedType);

            if (result == null)
                return new ServerResponse<IList<HospitalBedModel>> { Message = Messages.ErrorOccured };
            else if(!result.Any())
                return new ServerResponse<IList<HospitalBedModel>> { Message = Messages.NoHospitalBedsFound };
            else
                return new ServerResponse<IList<HospitalBedModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
