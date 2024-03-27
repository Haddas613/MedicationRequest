using PatientMedicationApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace PatientMedicationApi.Models
{
    public class Patient : EntityName
    {
        [Required]
        [Key]
        [StringLength(9, MinimumLength = 9)]
        public required string Identity { get; set; }
       
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
    }
}
