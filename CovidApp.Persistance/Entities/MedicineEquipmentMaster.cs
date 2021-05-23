using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("MedicineEquipmentMaster")]
    public partial class MedicineEquipmentMaster
    {
        public MedicineEquipmentMaster()
        {
            MedicineEquipments = new HashSet<MedicineEquipment>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(200)]
        public string MedicineEquipmentName { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [InverseProperty(nameof(MedicineEquipment.MedicineEquipmentNavigation))]
        public virtual ICollection<MedicineEquipment> MedicineEquipments { get; set; }
    }
}
