using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("Ambulance")]
    public partial class Ambulance
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(200)]
        public string AmbulanceName { get; set; }
        public long CityId { get; set; }
        public bool? IsAirConditioned { get; set; }
        public bool? OxygenAvailable { get; set; }
        public bool? ProvidesOutstationService { get; set; }
        public bool? AcceptsCovidPatient { get; set; }
        [StringLength(50)]
        public string Charges { get; set; }
        public bool IsVerified { get; set; }
        [StringLength(50)]
        public string Timing { get; set; }
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
        [InverseProperty("Ambulances")]
        public virtual City City { get; set; }
    }
}
