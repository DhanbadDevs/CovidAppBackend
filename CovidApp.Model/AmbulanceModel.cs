using System;

namespace CovidApp.Model
{
    public class AmbulanceModel
    {
        public long Id { get; set; }
        public string AmbulanceName { get; set; }
        public bool IsAirConditioned { get; set; }
        public bool OxygenAvailable { get; set; }
        public bool ProvidesOutstationService { get; set; }
        public bool AcceptsCovidPatient { get; set; }
        public string Charges { get; set; }
        public bool IsVerified { get; set; }
        public string Timing { get; set; }
        public string Notes { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Phone { get; set; }
        public int Votes { get; set; }
        public DateTime CreatedOn { get; set; }
        public CityModel City { get; set; }

        public static implicit operator AmbulanceModel(Tuple<AmbulanceModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
