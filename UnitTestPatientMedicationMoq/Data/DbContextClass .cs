using Microsoft.EntityFrameworkCore;
using PatientMedicationApi.Models;

namespace UnitTestPatientMedicationMoq.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<MedicationRequest> MedicationRequests { get; set; }
        public DbSet<Clinician> Clinicians { get; set; }
        public DbSet<Medication> Medications { get; set; }

    }
}
