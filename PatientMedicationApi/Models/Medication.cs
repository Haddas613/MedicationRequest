using Newtonsoft.Json.Converters;
using PatientMedicationApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PatientMedicationApi.Models
{
    public class Medication
    {
        [Required]
        [Key]
        [StringLength(50, MinimumLength = 2)]
        public required string Code { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public required string Name { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public required string CodeSystem { get; set; }
       
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The field Strength must be greater than 0.")]
        public int Strength { get; set; }

        [Required]
        [EnumDataType(typeof(Unit))]
        [JsonConverter(typeof(StringEnumConverter))]
        public Unit StrengthUnit {get;set;}

        [Required]
        public Form Form { get; set; }

    }
}
