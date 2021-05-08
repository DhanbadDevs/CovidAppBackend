﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class HospitalBedModel
    {
        public long Id { get; set; }
        public string BedType { get; set; }
        public int? BedCount { get; set; }
        public long CityId { get; set; }
        public string Charges { get; set; }
        public long LocationId { get; set; }
        public bool IsVerified { get; set; }
        public string Notes { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Phone { get; set; }
        public int? Votes { get; set; }
        public DateTime CreatedOn { get; set; }
        public CityModel City { get; set; }
        public LocationModel Location { get; set; }
    }
}
