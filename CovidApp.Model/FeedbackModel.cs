using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class FeedbackModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CityId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual CityModel City { get; set; }
    }
}
