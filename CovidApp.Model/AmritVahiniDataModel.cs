using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Integration.AmritVahini
{
    public class AmritVahiniDataModel
    {
        public string HospitalName { get; set; }
        public string WithoutOxygen { get; set; }
        public string WithOxygen { get; set; }
        public string IcuWithoutVentilator { get; set; }
        public string IcuWithVentilator { get; set; }
        public string UpdatedOn { get; set; }
    }
}
