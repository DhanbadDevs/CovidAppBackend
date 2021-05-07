using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp.Controllers
{
    [Route("api/oxygen")]
    public class OxygenController:Controller
    {
        readonly IOxygenDelegate
    }
}
