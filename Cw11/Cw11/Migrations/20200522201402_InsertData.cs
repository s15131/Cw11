using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw11.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 10, "jkowalski@klinika.pl", "Jan", "Kowalski" },
                    { 11, "mgrosz@klinika.pl", "Marcin", "Grosz" },
                    { 12, "awojciechowska@klinika.pl", "Anna", "Wojciechowska" },
                    { 13, "msyta@klinika.pl", "Marika", "Syta" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Produkt leczniczy stosowany", "Rutinoscorbin", "Lek bez recepty" },
                    { 2, "Zakażenia dolnych dróg oddechowych", "Azitrox", "Lek na receptę" },
                    { 3, "Opioidowy", "Sevredol", "Lek na receptę" },
                    { 4, " ibuprofen oraz paracetamol", "Kidofen duo", "Lek na receptę" },
                    { 5, "Lek nasenny i uspokajający", "Nasen", "Lek na receptę" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marta", "Nowak" },
                    { 2, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kacper", "Dobry" },
                    { 3, new DateTime(1999, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kinga", "Grosz" },
                    { 4, new DateTime(1990, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ola", "Boska" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 2, new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 2 },
                    { 3, new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 3 },
                    { 4, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "W stanach niedoboru witaminy C.", 4 },
                    { 5, 1, "5 ml przed snem.", 5 },
                    { 2, 2, "Stosować przez 3 dni.", 1 },
                    { 3, 3, "Co 4 godziny 20mg.", 20 },
                    { 4, 4, "10 ml co 4 godziny, nie więcej niż 60 ml na dobę.", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4);
        }
    }
}
