﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CovidApp.Model;

namespace CovidApp.Core.API.Delegates
{
    public interface IAmbulanceDelegate
    {
        Task<ServerResponse<IList<AmbulanceModel>>> GetAmbulances();
    }
}
