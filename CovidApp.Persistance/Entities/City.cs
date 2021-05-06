using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            Ambulances = new HashSet<Ambulance>();
            Doctors = new HashSet<Doctor>();
            HospitalBeds = new HashSet<HospitalBed>();
            Locations = new HashSet<Location>();
            MedicineEquipments = new HashSet<MedicineEquipment>();
            Ngos = new HashSet<Ngo>();
            Oxygens = new HashSet<Oxygen>();
            TestingCentres = new HashSet<TestingCentre>();
            VaccinationCentres = new HashSet<VaccinationCentre>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [InverseProperty(nameof(Ambulance.City))]
        public virtual ICollection<Ambulance> Ambulances { get; set; }
        [InverseProperty(nameof(Doctor.City))]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [InverseProperty(nameof(HospitalBed.City))]
        public virtual ICollection<HospitalBed> HospitalBeds { get; set; }
        [InverseProperty(nameof(Location.City))]
        public virtual ICollection<Location> Locations { get; set; }
        [InverseProperty(nameof(MedicineEquipment.City))]
        public virtual ICollection<MedicineEquipment> MedicineEquipments { get; set; }
        [InverseProperty(nameof(Ngo.City))]
        public virtual ICollection<Ngo> Ngos { get; set; }
        [InverseProperty(nameof(Oxygen.City))]
        public virtual ICollection<Oxygen> Oxygens { get; set; }
        [InverseProperty(nameof(TestingCentre.City))]
        public virtual ICollection<TestingCentre> TestingCentres { get; set; }
        [InverseProperty(nameof(VaccinationCentre.City))]
        public virtual ICollection<VaccinationCentre> VaccinationCentres { get; set; }
    }
}
