using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CovidApp.Persistance.Entities;

#nullable disable

namespace CovidApp.Persistance.CovidAppContext
{
    public partial class CovidAppDbContext : DbContext
    {
        public CovidAppDbContext()
        {
        }

        public CovidAppDbContext(DbContextOptions<CovidAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ambulance> Ambulances { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Helpline> Helplines { get; set; }
        public virtual DbSet<HelplineCategory> HelplineCategories { get; set; }
        public virtual DbSet<HospitalBed> HospitalBeds { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationType> LocationTypes { get; set; }
        public virtual DbSet<MedicineEquipment> MedicineEquipments { get; set; }
        public virtual DbSet<MedicineEquipmentMaster> MedicineEquipmentMasters { get; set; }
        public virtual DbSet<Ngo> Ngos { get; set; }
        public virtual DbSet<Oxygen> Oxygens { get; set; }
        public virtual DbSet<TestingCentre> TestingCentres { get; set; }
        public virtual DbSet<VaccinationCentre> VaccinationCentres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ambulance>(entity =>
            {
                entity.Property(e => e.AmbulanceName).IsUnicode(false);

                entity.Property(e => e.Charges).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Timing).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Ambulances)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ambulance_City");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Designation).IsUnicode(false);

                entity.Property(e => e.DoctorName).IsUnicode(false);

                entity.Property(e => e.Fees).IsUnicode(false);

                entity.Property(e => e.Medium).IsUnicode(false);

                entity.Property(e => e.MediumLink).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Timing).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Docter_City");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Docter_Location");
            });

            modelBuilder.Entity<Helpline>(entity =>
            {
                entity.Property(e => e.HelplineName).IsUnicode(false);

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Timing).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Helplines)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Helpline_City");
            });

            modelBuilder.Entity<HelplineCategory>(entity =>
            {
                entity.Property(e => e.HelplineCategoryName).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<HospitalBed>(entity =>
            {
                entity.Property(e => e.BookingLink).IsUnicode(false);

                entity.Property(e => e.Charges).IsUnicode(false);

                entity.Property(e => e.IcuWithVentilator).IsUnicode(false);

                entity.Property(e => e.IcuWithoutVentilator).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.Property(e => e.WithOxygen).IsUnicode(false);

                entity.Property(e => e.WithoutOxygen).IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.HospitalBeds)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HospitalBeds_City");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.HospitalBeds)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HospitalBeds_Location");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Latitude).IsUnicode(false);

                entity.Property(e => e.LocationName).IsUnicode(false);

                entity.Property(e => e.Longitude).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Timing).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_City");

                entity.HasOne(d => d.LocationType)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.LocationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_LocationType");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.Property(e => e.LocationTypeName).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MedicineEquipment>(entity =>
            {
                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Price).IsUnicode(false);

                entity.Property(e => e.Timing).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.MedicineEquipments)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineEquipment_City");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.MedicineEquipments)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineEquipment_Location");

                entity.HasOne(d => d.MedicineEquipmentNavigation)
                    .WithMany(p => p.MedicineEquipments)
                    .HasForeignKey(d => d.MedicineEquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineEquipment_MedicineEquipmentMaster");
            });

            modelBuilder.Entity<MedicineEquipmentMaster>(entity =>
            {
                entity.Property(e => e.MedicineEquipmentName).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Ngo>(entity =>
            {
                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.NgoType).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Ngos)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ngo_City");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Ngos)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ngo_Location");
            });

            modelBuilder.Entity<Oxygen>(entity =>
            {
                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Price).IsUnicode(false);

                entity.Property(e => e.Timing).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Oxygens)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Oxygen_City");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Oxygens)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Oxygen_Location");
            });

            modelBuilder.Entity<TestingCentre>(entity =>
            {
                entity.Property(e => e.ApproxReportingTime).IsUnicode(false);

                entity.Property(e => e.Charges).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.TestType).IsUnicode(false);

                entity.Property(e => e.Timing).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TestingCentres)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestingCentre_City");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TestingCentres)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestingCentre_Location");
            });

            modelBuilder.Entity<VaccinationCentre>(entity =>
            {
                entity.Property(e => e.AgeGroup).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Price).IsUnicode(false);

                entity.Property(e => e.Timing).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VaccineName).IsUnicode(false);

                entity.Property(e => e.Votes).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.VaccinationCentres)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VaccinationCentre_City");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.VaccinationCentres)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VaccinationCentre_Location");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
