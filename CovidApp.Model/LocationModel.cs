using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public bool? IsPrivate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int TypeId { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public CityModel City { get; set; }
        public LocationTypeModel Type { get; set; }
    }
}
