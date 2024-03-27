using System.ComponentModel.DataAnnotations;

namespace PatientMedicationApi.Models
{
    public class EntityName
    {
        [Required]
        [StringLength(50, MinimumLength =2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
