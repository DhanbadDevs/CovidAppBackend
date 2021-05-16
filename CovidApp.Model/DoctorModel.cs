using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class DoctorModel
    {
        public long Id { get; set; }
        public string DoctorName { get; set; }
        public string Timing { get; set; }
        public long CityId { get; set; }
        public string Designation { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public string Medium { get; set; }
        public string Fees { get; set; }
        public bool IsVerified { get; set; }
        public string MediumLink { get; set; }
        public string Notes { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Phone { get; set; }
        public int? Votes { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Address { get; set; }
        public CityModel City { get; set; }

    }
}
