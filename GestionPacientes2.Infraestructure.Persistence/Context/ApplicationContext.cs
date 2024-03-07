
using GestionPacientes2.Core.Domain.Entities;
using GestionPacientes2.Core.Domain.Entities.joins;
using Microsoft.EntityFrameworkCore;

namespace GestionPacientes2.Infrastructure.Persitence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        #region TABLES
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<PacientDate> PacientDates { get; set; }
        public DbSet<TestResult> Results { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables
            modelBuilder.Entity<Doctor>()
             .ToTable("Doctors");

            modelBuilder.Entity<Pacient>()
             .ToTable("Pacients");

            modelBuilder.Entity<User>()
             .ToTable("Users");

            modelBuilder.Entity<LabTest>()
             .ToTable("LabTests");

            modelBuilder.Entity<TestResult>()
             .ToTable("TestResults");

            modelBuilder.Entity<PacientDate>()
             .ToTable("PacientDate");



            #endregion


            #region Primary Keys

            modelBuilder.Entity<Doctor>()
                .HasKey(doctor => doctor.Id);

            modelBuilder.Entity<Pacient>()
                .HasKey(pacient => pacient.Id);

            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);

            modelBuilder.Entity<LabTest>()
                .HasKey(labTest => labTest.Id);

            modelBuilder.Entity<PacientDate>()
                .HasKey(pacientDate => pacientDate.Id);

            modelBuilder.Entity<TestResult>()
                .HasKey(testResult => testResult.Id);


            #endregion

            #region relationships

            modelBuilder.Entity<Doctor_Pacient>()
            .HasKey(dp => new { dp.DoctorId, dp.PacientId });

            modelBuilder.Entity<Doctor_Pacient>()
                .HasOne(dp => dp.Doctor)
                .WithMany(d => d.Doctor_Pacients)
                .HasForeignKey(dp => dp.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<LabTest_Pacient>()
            .HasKey(lp => new { lp.PacientId, lp.LabTestId });

            modelBuilder.Entity<LabTest_Pacient>()
                .HasOne(lp => lp.Pacient)
                .WithMany(p => p.LabTest_Pacients)
                .HasForeignKey(lb => lb.PacientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor_PacientDate>()
       .HasKey(dp => new { dp.PacientDateId, dp.DoctorId });

            modelBuilder.Entity<Doctor_PacientDate>()
                .HasOne(dp => dp.PacientDate)
                .WithOne(p => p.Doctor_PacientDate)
                .HasForeignKey<Doctor_PacientDate>(dp => dp.PacientDateId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Pacient_TestResult>()
       .HasKey(lp => new { lp.PacientId, lp.TestResultId });

            modelBuilder.Entity<Pacient_TestResult>()
                .HasOne(lp => lp.TestResult)
                .WithOne(t => t.Pacient_TestResult)
                .HasForeignKey<Pacient_TestResult>(t => t.TestResultId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Property configuration

            #region Doctor

            modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.Name)
                .IsRequired();


            modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.LastName)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.Phone)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.Identification)
                .IsRequired();


            #endregion
            #region Pacient

            modelBuilder.Entity<Pacient>()
                .Property(pacient => pacient.Name)
                .IsRequired();


            modelBuilder.Entity<Pacient>()
                .Property(pacient => pacient.LastName)
                .IsRequired();

            modelBuilder.Entity<Pacient>()
                .Property(pacient => pacient.Identification)
                .IsRequired();

            modelBuilder.Entity<Pacient>()
                .Property(pacient => pacient.BornDate)
                .IsRequired();

            modelBuilder.Entity<Pacient>()
                .Property(pacient => pacient.Alergies)
                .IsRequired();

            modelBuilder.Entity<Pacient>()
                .Property(pacient => pacient.Direction)
                .IsRequired();


            modelBuilder.Entity<Pacient>()
                .Property(pacient => pacient.Smooker)
                .IsRequired();
            #endregion
            #region User

            modelBuilder.Entity<User>()
                .Property(user => user.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Access)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.LastName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.UserName)
                .IsRequired();

            #endregion
            #region TestResult


            modelBuilder.Entity<TestResult>()
                .Property(testResult => testResult.Status)
                .IsRequired();


            #endregion
            #region LabTest

            modelBuilder.Entity<LabTest>()
                .Property(labTest => labTest.Name)
                .IsRequired();
            #endregion
            #region PacientDate

            modelBuilder.Entity<PacientDate>()
                .Property(pacientDate => pacientDate.Status)
                .IsRequired();


            modelBuilder.Entity<PacientDate>()
                .Property(pacientDate => pacientDate.DateDay)
                .IsRequired();


            modelBuilder.Entity<PacientDate>()
                .Property(pacientDate => pacientDate.Hour)
                .IsRequired();


            modelBuilder.Entity<PacientDate>()
                .Property(pacientDate => pacientDate.Reason)
                .IsRequired();

            #endregion
            #region Doctor
            #endregion

            #endregion

        }

    }
}
