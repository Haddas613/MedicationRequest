using Microsoft.EntityFrameworkCore;
namespace PatientMedicationApi.Models
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
        : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; } = null!;
    }
}
