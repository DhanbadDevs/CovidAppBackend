using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("Doctor")]
    public partial class Doctor
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string DoctorName { get; set; }
        [StringLength(50)]
        public string Timing { get; set; }
        public long CityId { get; set; }
        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(100)]
        public string Experience { get; set; }
        [StringLength(200)]
        public string Qualification { get; set; }
        [Required]
        [StringLength(50)]
        public string Medium { get; set; }
        [StringLength(50)]
        public string Fees { get; set; }
        public bool IsVerified { get; set; }
        [StringLength(500)]
        public string MediumLink { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        public int? Votes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [StringLength(500)]
        public string Address { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Doctors")]
        public virtual City City { get; set; }
    }
}
