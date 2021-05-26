using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("Volunteer")]
    public partial class Volunteer
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string VolunteerName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Occupation { get; set; }
        [StringLength(500)]
        public string About { get; set; }
        [StringLength(100)]
        public string Timing { get; set; }
        [StringLength(200)]
        public string Skills { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [StringLength(100)]
        public string City { get; set; }
    }
}
