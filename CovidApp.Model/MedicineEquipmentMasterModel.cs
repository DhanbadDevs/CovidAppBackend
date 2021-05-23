using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class MedicineEquipmentMasterModel
    {
        public long Id { get; set; }
        public string MedicineEquipmentName { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
