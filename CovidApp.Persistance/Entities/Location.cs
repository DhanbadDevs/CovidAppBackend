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
            Doctors = new HashSet<Doctor>();
            HospitalBeds = new HashSet<HospitalBed>();
            MedicineEquipments = new HashSet<MedicineEquipment>();
            Ngos = new HashSet<Ngo>();
            Oxygens = new HashSet<Oxygen>();
            TestingCentres = new HashSet<TestingCentre>();
            VaccinationCentres = new HashSet<VaccinationCentre>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(200)]
        public string LocationName { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Column("isPrivate")]
        public bool? IsPrivate { get; set; }
        public long CityId { get; set; }
        [StringLength(100)]
        public string Latitude { get; set; }
        [StringLength(100)]
        public string Longitude { get; set; }
        [StringLength(50)]
        public string Timing { get; set; }
        public long LocationTypeId { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public int? Votes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Locations")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(LocationTypeId))]
        [InverseProperty("Locations")]
        public virtual LocationType LocationType { get; set; }
        [InverseProperty(nameof(Doctor.Location))]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [InverseProperty(nameof(HospitalBed.Location))]
        public virtual ICollection<HospitalBed> HospitalBeds { get; set; }
        [InverseProperty(nameof(MedicineEquipment.Location))]
        public virtual ICollection<MedicineEquipment> MedicineEquipments { get; set; }
        [InverseProperty(nameof(Ngo.Location))]
        public virtual ICollection<Ngo> Ngos { get; set; }
        [InverseProperty(nameof(Oxygen.Location))]
        public virtual ICollection<Oxygen> Oxygens { get; set; }
        [InverseProperty(nameof(TestingCentre.Location))]
        public virtual ICollection<TestingCentre> TestingCentres { get; set; }
        [InverseProperty(nameof(VaccinationCentre.Location))]
        public virtual ICollection<VaccinationCentre> VaccinationCentres { get; set; }
    }
}
