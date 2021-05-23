using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class LocationTypeModel
    {
        public long Id { get; set; }
        public string LocationTypeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
