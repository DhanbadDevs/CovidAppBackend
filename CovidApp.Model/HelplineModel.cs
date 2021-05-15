using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class HelplineModel
    {
        public long Id { get; set; }
        public string HelplineName { get; set; }
        public long? CityId { get; set; }
        public string Timing { get; set; }
        public string Notes { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Phone { get; set; }
        public string Link { get; set; }
        public int? Votes { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual CityModel City { get; set; }
    }
}
