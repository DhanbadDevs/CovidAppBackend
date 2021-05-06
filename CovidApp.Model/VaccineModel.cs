using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class VaccineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public string AgeGroup { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public int? Votes { get; set; }
        public bool IsVerified { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public LocationModel Location { get; set; }
    }
}
