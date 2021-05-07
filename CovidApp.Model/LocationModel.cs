using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class LocationModel
    {
        public long Id { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public bool IsPrivate { get; set; }
        public long CityId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Timing { get; set; }
        public long LocationTypeId { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Votes { get; set; }
        public DateTime CreatedOn { get; set; }
        public CityModel City { get; set; }
        public LocationTypeModel LocationType { get; set; }
    }
}
