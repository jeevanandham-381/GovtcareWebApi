using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public IConfigurationRoot Configuration { get; set; }
        public DbSet<Hospital> hospitals { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<Lov> lov { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options , IConfiguration configuration): base(options)
        {
            Configuration = (IConfigurationRoot)configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DatabaseContext"));
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasIndex(h => h.DistrictId).HasName("IX_District_DistrictId");
                entity.HasOne(h => h.Districts).
                WithMany(h => h.Hospital)
                .HasForeignKey(h => h.DistrictId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Hospital_District_hospitalId");

                entity.HasIndex(h => h.PatientId).HasName("IX_Patient_PatientId");
                entity.HasMany(l => l.Lov).
                WithMany(l => l.Hospital);
                modelBuilder.Entity<Patient>()
               .HasOne(p => p.Hospital)
               .WithMany(h => h.Patients)
               .HasForeignKey(p => p.HospitalId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Hospital_District_hospitalId");



                base.OnModelCreating(modelBuilder);

            });
        }
    }
}
