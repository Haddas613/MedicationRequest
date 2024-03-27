using PatientMedicationApi.Enums;
using PatientMedicationApi.Models;

namespace UnitTestPatientMedicationMoq.Services
{
    public interface IMedicationRequestService
    {
        public IEnumerable<MedicationRequest> GetMedicationRequestList();
        public List<MedicationPrescriptionResponse> GetMedicationRequests(PrescriptionStatus? Status, DateTime? fromDate, DateTime? toDate);
        public MedicationRequest AddMedicationRequest(MedicationRequest medicationRequest);
        public void UpdateMedicationRequest(string clinicianRegistrationID,  string patientIdentity,  string medicationCode, DateTime endDate, PrescriptionStatus status);
    }
}
