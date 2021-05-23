using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("VaccinationCentre")]
    public partial class VaccinationCentre
    {
        [Key]
        public long Id { get; set; }
        [StringLength(200)]
        public string VaccineName { get; set; }
        public long LocationId { get; set; }
        public long CityId { get; set; }
        [StringLength(50)]
        public string Price { get; set; }
        [StringLength(20)]
        public string AgeGroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string Timing { get; set; }
        public bool IsAvailable { get; set; }
        public int? Votes { get; set; }
        public bool IsVerified { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("VaccinationCentres")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(LocationId))]
        [InverseProperty("VaccinationCentres")]
        public virtual Location Location { get; set; }
    }
}
