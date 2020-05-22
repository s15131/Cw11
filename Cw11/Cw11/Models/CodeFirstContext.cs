using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cw11.Models
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }


        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient);
                entity.Property(e => e.IdPatient).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();


                var patients = new List<Patient>();
                patients.Add(new Patient { IdPatient = 1, FirstName = "Marta", LastName = "Nowak", Birthdate = new DateTime(2000, 4, 21) });
                patients.Add(new Patient { IdPatient = 2, FirstName = "Kacper", LastName = "Dobry", Birthdate = new DateTime(1995, 1, 1) });
                patients.Add(new Patient { IdPatient = 3, FirstName = "Kinga", LastName = "Grosz", Birthdate = new DateTime(1999, 8, 15) });
                patients.Add(new Patient { IdPatient = 4, FirstName = "Ola", LastName = "Boska", Birthdate = new DateTime(1990, 3, 10) });
                entity.HasData(patients);
            });
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.IdDoctor).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();


                var doctors = new List<Doctor>();
                doctors.Add(new Doctor { IdDoctor = 10, FirstName = "Jan", LastName = "Kowalski", Email = "jkowalski@klinika.pl" });
                doctors.Add(new Doctor { IdDoctor = 11, FirstName = "Marcin", LastName = "Grosz", Email = "mgrosz@klinika.pl" });
                doctors.Add(new Doctor { IdDoctor = 12, FirstName = "Anna", LastName = "Wojciechowska", Email = "awojciechowska@klinika.pl" });
                doctors.Add(new Doctor { IdDoctor = 13, FirstName = "Marika", LastName = "Syta", Email = "msyta@klinika.pl" });
                entity.HasData(doctors);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription);
                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(d => d.Patient)
                .WithMany(p => p.Prescription)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Patient");

                entity.HasOne(d => d.Doctor)
               .WithMany(p => p.Prescription)
               .HasForeignKey(d => d.IdDoctor)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Prescription_Doctor");


                var prescriptions = new List<Prescription>();
                prescriptions.Add(new Prescription { IdPrescription = 1, Date = new DateTime(2020, 1, 1), DueDate = new DateTime(2020, 2, 1), IdDoctor = 13, IdPatient = 1 });
                prescriptions.Add(new Prescription { IdPrescription = 2, Date = new DateTime(2020, 1, 12), DueDate = new DateTime(2020, 2, 12), IdDoctor = 12, IdPatient = 2 });
                prescriptions.Add(new Prescription { IdPrescription = 3, Date = new DateTime(2020, 3, 21), DueDate = new DateTime(2020, 4, 21), IdDoctor = 11, IdPatient = 3 });
                prescriptions.Add(new Prescription { IdPrescription = 4, Date = new DateTime(2020, 4, 8), DueDate = new DateTime(2020, 5, 8), IdDoctor = 10, IdPatient = 4 });
                entity.HasData(prescriptions);

            });
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();

                var medicaments = new List<Medicament>();
                medicaments.Add(new Medicament { IdMedicament = 1, Name = "Rutinoscorbin", Description = "Produkt leczniczy stosowany", Type = "Lek bez recepty" });
                medicaments.Add(new Medicament { IdMedicament = 2, Name = "Azitrox", Description = "Zakażenia dolnych dróg oddechowych", Type = "Lek na receptę" });
                medicaments.Add(new Medicament { IdMedicament = 3, Name = "Sevredol", Description = "Opioidowy", Type = "Lek na receptę" });
                medicaments.Add(new Medicament { IdMedicament = 4, Name = "Kidofen duo", Description = " ibuprofen oraz paracetamol", Type = "Lek na receptę" });
                medicaments.Add(new Medicament { IdMedicament = 5, Name = "Nasen", Description = "Lek nasenny i uspokajający", Type = "Lek na receptę" });
                entity.HasData(medicaments);

            });
            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Dose);
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(d => d.Medicament)
                .WithMany(p => p.PrescriptionMedicament)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PrescriptionMedicament_Medicament");

                entity.HasOne(d => d.Prescription)
               .WithMany(p => p.PrescriptionMedicament)
               .HasForeignKey(d => d.IdPrescription)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Prescription_Prescription");


                var PrescriptionsMedicaments = new List<PrescriptionMedicament>();
                PrescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Details = "W stanach niedoboru witaminy C.", Dose = 4 });
                PrescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Details = "Stosować przez 3 dni.", Dose = 1 });
                PrescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 3, Details = "Co 4 godziny 20mg.", Dose = 20 });
                PrescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 4, IdPrescription = 4, Details = "10 ml co 4 godziny, nie więcej niż 60 ml na dobę.", Dose = 10 });
                PrescriptionsMedicaments.Add(new PrescriptionMedicament { IdMedicament = 5, IdPrescription = 1, Details = "5 ml przed snem.", Dose = 5 });
                entity.HasData(PrescriptionsMedicaments);
            });

        }
        }
}
