using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class VolunteerModel
    {
        public long Id { get; set; }
        public string VolunteerName { get; set; }
        public long CityId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Occupation { get; set; }
        public string About { get; set; }
        public string Timing { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public CityModel City { get; set; }
    }
}
