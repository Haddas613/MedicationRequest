using System.ComponentModel.DataAnnotations;

namespace PatientMedicationApi.Models
{
    public class Clinician : EntityName
    {
        [Key]
        [Required]
        public required string RegistrationID { get; set; }

    }
}
