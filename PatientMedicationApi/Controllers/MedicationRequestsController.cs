using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http.OData.Routing;
using System.Xml.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PatientMedicationApi.Enums;
using PatientMedicationApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatientMedicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationRequestsController : ControllerBase
    {
        private readonly MedicationRequestContext _medicationRequestContext;
        private readonly ClinicianContext _clinicianContext;
        private readonly MedicationContext _medicationContext;

        public MedicationRequestsController(MedicationRequestContext contextMedicationRequest, ClinicianContext contextClinicianRequest, MedicationContext contextMedication)
        {
            _medicationRequestContext = contextMedicationRequest;
            _clinicianContext = contextClinicianRequest;
            _medicationContext = contextMedication;
        }

        /*// GET: api/MedicationRequests
       
        public async Task<ActionResult<IEnumerable<MedicationRequest>>> GetMedicationRequests()
        {
            return await _context.MedicationRequests.ToListAsync();
        }
        */
        [HttpGet]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Status">filtering by status of medication request</param>
        /// <param name="fromDate">filtering by start date of medication request </param>
        /// <param name="toDate">filtering by end date of medication request</param>
        /// <returns></returns>
        public async Task<ActionResult<List<MedicationPrescriptionResponse>>> GetMedicationRequest(PrescriptionStatus? Status, DateTime? fromDate, DateTime? toDate)
        {
            var medicationPrescriptionsResponse =await (from m in _medicationRequestContext.MedicationRequests.Where(m => !Status.HasValue || m.Status == Status
            && (!fromDate.HasValue || fromDate >= m.StartDate) && (!toDate.HasValue || toDate <= m.EndDate))
                          let clinician = _clinicianContext.Clinicians.Where(c => c.RegistrationID == m.ClinicianRegistrationID).FirstOrDefault()
                          let medication = _medicationContext.Medications.Where(md => md.Code == m.MedicationCode).FirstOrDefault()
                          select new MedicationPrescriptionResponse()
                          {
                              ClinicianRegistrationID = m.ClinicianRegistrationID,
                              Frequency = m.Frequency,
                              PatientIdentity = m.PatientIdentity,
                              ClinicianFirstName = _clinicianContext == null || clinician == null ? string.Empty : clinician.FirstName,
                              ClinicianLastName = _clinicianContext == null || clinician == null ? string.Empty : clinician.LastName,
                              EndDate = m.EndDate,
                              MedicationCode = m.MedicationCode,
                              MedicationName = _medicationContext == null || medication == null ? string.Empty : medication.Name,
                              Reason = m.Reason,
                              StartDate = m.StartDate,
                              Status = m.Status
                          }).ToListAsync();

            
            if (medicationPrescriptionsResponse == null || medicationPrescriptionsResponse.Count == 0)
            {
                return NotFound();
            }

            return medicationPrescriptionsResponse;
        }

        [HttpPatch]
        [ODataRoute("PatchMedicationRequest(ClinicianRegistrationID={clinicianRegistrationID}, PatientIdentity={patientIdentity},  MedicationCode={medicationCode} )")]
        public async Task<IActionResult> PutMedicationRequest([FromODataUri] string clinicianRegistrationID, [FromODataUri] string patientIdentity, [FromODataUri] string medicationCode, DateTime endDate, PrescriptionStatus status)
        {
            var md = await _medicationRequestContext.MedicationRequests.Where(m => m.ClinicianRegistrationID == clinicianRegistrationID && m.PatientIdentity == patientIdentity && m.MedicationCode == medicationCode).FirstOrDefaultAsync();

            if (md == null)
            {
                return NotFound();
            }

            _medicationRequestContext.Entry(md).State = EntityState.Modified;
            md.Status = status;
            md.EndDate = endDate;

            try
            {
                await _medicationRequestContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationRequestExists(patientIdentity, clinicianRegistrationID, medicationCode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MedicationRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Create Medication Prescription
        /// </summary>
        /// <param name="medicationRequest"> medication prescription information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MedicationRequest>> PostMedicationRequest([FromBody] MedicationRequest medicationRequest)
        {
            _medicationRequestContext.MedicationRequests.Add(medicationRequest);
            try
            {
                await _medicationRequestContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicationRequestExists(medicationRequest.PatientIdentity, medicationRequest.ClinicianRegistrationID, medicationRequest.MedicationCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicationRequest", new { id = medicationRequest.PatientIdentity }, medicationRequest);
        }

        private bool MedicationRequestExists(string patientId, string clinicianID, string medicationCode)
        {
            return _medicationRequestContext.MedicationRequests.Any(m => m.PatientIdentity == patientId && m.ClinicianRegistrationID == clinicianID && m.MedicationCode == medicationCode);
        }
    }
}
