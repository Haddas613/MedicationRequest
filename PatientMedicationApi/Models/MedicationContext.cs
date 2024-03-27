using Microsoft.EntityFrameworkCore;

namespace PatientMedicationApi.Models
{
    public class MedicationContext : DbContext
    {
        public MedicationContext(DbContextOptions<MedicationContext> options)
        : base(options)
        {
        }

        public DbSet<Medication> Medications { get; set; } = null!;
    }
}
