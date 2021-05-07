using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class CityModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
