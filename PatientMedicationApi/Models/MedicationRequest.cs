using PatientMedicationApi.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore;

namespace PatientMedicationApi.Models
{
    [PrimaryKey(nameof(PatientIdentity), nameof(ClinicianRegistrationID), nameof(MedicationCode))]
    public class MedicationRequest
    {
        [Required]
        [StringLength(9)]
        [Column("PatientIdentity", Order = 0)]
        public required string PatientIdentity { get; set; }

        [Required]
        [Column("ClinicianRegistrationID", Order = 1)]
        public required string ClinicianRegistrationID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Column("MedicationCode", Order = 2)]
        public string MedicationCode { get; set; }
        public string? Reason { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required Frequency Frequency { get; set; }
        public PrescriptionStatus Status { get; set; }
    }
}
