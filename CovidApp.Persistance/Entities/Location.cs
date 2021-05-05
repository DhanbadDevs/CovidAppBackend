using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("Location")]
    public partial class Location
    {
        public Location()
        {
            Vaccines = new HashSet<Vaccine>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public int CityId { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Column("isPrivate")]
        public bool? IsPrivate { get; set; }
        [StringLength(100)]
        public string Latitude { get; set; }
        [StringLength(100)]
        public string Longitude { get; set; }
        public int TypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(500)]
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Locations")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(LocationType.Locations))]
        public virtual LocationType Type { get; set; }
        [InverseProperty(nameof(Vaccine.Location))]
        public virtual ICollection<Vaccine> Vaccines { get; set; }
    }
}
