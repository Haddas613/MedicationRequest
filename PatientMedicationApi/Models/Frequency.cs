using Microsoft.EntityFrameworkCore;
using PatientMedicationApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientMedicationApi.Models
{
    [PrimaryKey(nameof(Amount), nameof(UnitTime))]
    public class Frequency
    {
        [Column("Amount", Order = 0)]
        [Range(1, 500, ErrorMessage = "The field Amount must be greater than 0.")]
        public int Amount { get; set; }

        [Column("UnitTime", Order = 1)]
        public UnitTime UnitTime {get;set;}
    }
}
