using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitTestPatientMedicationMoq.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinicians",
                columns: table => new
                {
                    RegistrationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicians", x => x.RegistrationID);
                });

            migrationBuilder.CreateTable(
                name: "Frequency",
                columns: table => new
                {
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequency", x => new { x.Amount, x.UnitTime });
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodeSystem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    StrengthUnit = table.Column<int>(type: "int", nullable: false),
                    Form = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "MedicationRequests",
                columns: table => new
                {
                    PatientIdentity = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    ClinicianRegistrationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FrequencyAmount = table.Column<int>(type: "int", nullable: false),
                    FrequencyUnitTime = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationRequests", x => new { x.PatientIdentity, x.ClinicianRegistrationID, x.MedicationCode });
                    table.ForeignKey(
                        name: "FK_MedicationRequests_Frequency_FrequencyAmount_FrequencyUnitTime",
                        columns: x => new { x.FrequencyAmount, x.FrequencyUnitTime },
                        principalTable: "Frequency",
                        principalColumns: new[] { "Amount", "UnitTime" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRequests_FrequencyAmount_FrequencyUnitTime",
                table: "MedicationRequests",
                columns: new[] { "FrequencyAmount", "FrequencyUnitTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinicians");

            migrationBuilder.DropTable(
                name: "MedicationRequests");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Frequency");
        }
    }
}
