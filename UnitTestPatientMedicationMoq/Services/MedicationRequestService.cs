using Microsoft.EntityFrameworkCore;
using PatientMedicationApi.Enums;
using PatientMedicationApi.Models;
using UnitTestPatientMedicationMoq.Data;

namespace UnitTestPatientMedicationMoq.Services
{
    public class MedicationRequestService : IMedicationRequestService
    {
        private readonly DbContextClass _dbContext;
        public MedicationRequestService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<MedicationRequest> GetMedicationRequestList()
        {
            return _dbContext.MedicationRequests.ToList();
        }
        public List<MedicationPrescriptionResponse> GetMedicationRequests(PrescriptionStatus? Status, DateTime? fromDate, DateTime? toDate)
        {
            return (from m in _dbContext.MedicationRequests.Where(m => !Status.HasValue || m.Status == Status
           && (!fromDate.HasValue || fromDate >= m.StartDate) && (!toDate.HasValue || toDate <= m.EndDate))
                                                        let clinician = _dbContext.Clinicians.Where(c => c.RegistrationID == m.ClinicianRegistrationID).FirstOrDefault()
                                                        let medication = _dbContext.Medications.Where(md => md.Code == m.MedicationCode).FirstOrDefault()
                                                        select new MedicationPrescriptionResponse()
                                                        {
                                                            ClinicianRegistrationID = m.ClinicianRegistrationID,
                                                            Frequency = m.Frequency,
                                                            PatientIdentity = m.PatientIdentity,
                                                            ClinicianFirstName = _dbContext.Clinicians == null || clinician == null ? string.Empty : clinician.FirstName,
                                                            ClinicianLastName = _dbContext.Clinicians == null || clinician == null ? string.Empty : clinician.LastName,
                                                            EndDate = m.EndDate,
                                                            MedicationCode = m.MedicationCode,
                                                            MedicationName = _dbContext.Medications == null || medication == null ? string.Empty : medication.Name,
                                                            Reason = m.Reason,
                                                            StartDate = m.StartDate,
                                                            Status = m.Status
                                                        }).ToList();
        }
        public MedicationRequest AddMedicationRequest(MedicationRequest medicationRequest)
        {
            var result = _dbContext.MedicationRequests.Add(medicationRequest);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public void UpdateMedicationRequest(string clinicianRegistrationID, string patientIdentity, string medicationCode, DateTime endDate, PrescriptionStatus status)
        {
            var md = _dbContext.MedicationRequests.Where(m => m.ClinicianRegistrationID == clinicianRegistrationID && m.PatientIdentity == patientIdentity && m.MedicationCode == medicationCode).FirstOrDefault();

            _dbContext.MedicationRequests.Entry(md).State = EntityState.Modified;
            md.Status = status;
            md.EndDate = endDate;

                 _dbContext.SaveChangesAsync();
                _dbContext.SaveChangesAsync();
        }
      
    }
}
