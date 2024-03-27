using Microsoft.AspNetCore.Mvc;
using PatientMedicationApi.Enums;
using PatientMedicationApi.Models;
using UnitTestPatientMedicationMoq.Services;

namespace UnitTestPatientMedicationMoq.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationRequestController : ControllerBase
    {
        private readonly IMedicationRequestService medicationRequestService;
        public MedicationRequestController(IMedicationRequestService _medicationRequestService)
        {
            medicationRequestService = _medicationRequestService;
        }
        [HttpGet("MedicationRequestslist")]
        public IEnumerable<MedicationRequest> MedicationRequestList()
        {
            var medicationRequestList = medicationRequestService.GetMedicationRequestList();
            return medicationRequestList;
        }
        [HttpGet("getmedicationrequestbystatusrange")]
        public List<MedicationPrescriptionResponse> GetMedicationRequests(PrescriptionStatus? Status, DateTime? fromDate, DateTime? toDate)
        {
            return medicationRequestService.GetMedicationRequests(Status, fromDate, toDate);
        }
        [HttpPost("addmedicationrequest")]
        public MedicationRequest AddMedicationRequest(MedicationRequest medicationRequest)
        {
            return medicationRequestService.AddMedicationRequest(medicationRequest);
        }

        [HttpPatch("updatemedicationrequest")]
        public void UpdateMedicationRequest(string clinicianRegistrationID, string patientIdentity, string medicationCode, DateTime endDate, PrescriptionStatus status)
        {
            medicationRequestService.UpdateMedicationRequest(clinicianRegistrationID, patientIdentity, medicationCode, endDate, status);
        }

    }
}
