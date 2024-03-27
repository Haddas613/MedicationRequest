using Microsoft.EntityFrameworkCore;

namespace PatientMedicationApi.Models
{
    public class ClinicianContext : DbContext
    {
        public ClinicianContext(DbContextOptions<ClinicianContext> options)
        : base(options)
        {
        }

        public DbSet<Clinician> Clinicians{ get; set; } = null!;
    }
}
