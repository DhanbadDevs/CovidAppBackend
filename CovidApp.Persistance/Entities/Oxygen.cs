using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("Oxygen")]
    public partial class Oxygen
    {
        [Key]
        public long Id { get; set; }
        public long LocationId { get; set; }
        public long CityId { get; set; }
        [StringLength(50)]
        public string Price { get; set; }
        public int? Stock { get; set; }
        [StringLength(50)]
        public string Timing { get; set; }
        public bool IsVerified { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        public int? Votes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Oxygens")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(LocationId))]
        [InverseProperty("Oxygens")]
        public virtual Location Location { get; set; }
    }
}
