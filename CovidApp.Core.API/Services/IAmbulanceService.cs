﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovidApp.Model;

namespace CovidApp.Core.API.Services
{
    public interface IAmbulanceService
    {
        Task<IList<AmbulanceModel>> GetAmbulances();
        Task<Tuple<AmbulanceModel>> AddAmbulance(AmbulanceModel ambulanceModel);
    }
}
