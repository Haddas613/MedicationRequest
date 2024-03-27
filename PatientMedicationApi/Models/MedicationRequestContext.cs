using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace PatientMedicationApi.Models
{
    public class MedicationRequestContext : DbContext
    {
        public MedicationRequestContext(DbContextOptions<MedicationRequestContext> options)
        : base(options)
        {
        }

        public DbSet<MedicationRequest> MedicationRequests { get; set; } = null!;

    }
}
