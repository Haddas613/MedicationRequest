using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientMedicationApi.Models;
/*
namespace PatientMedicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CliniciansController : ControllerBase
    {
        private readonly ClinicianContext _context;

        public CliniciansController(ClinicianContext context)
        {
            _context = context;
        }

        // GET: api/Clinicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinician>>> GetClinicians()
        {
            return await _context.Clinicians.ToListAsync();
        }

        // GET: api/Clinicians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinician>> GetClinician(string id)
        {
            var clinician = await _context.Clinicians.FindAsync(id);

            if (clinician == null)
            {
                return NotFound();
            }

            return clinician;
        }

        // PUT: api/Clinicians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinician(string id, Clinician clinician)
        {
            if (id != clinician.RegistrationID)
            {
                return BadRequest();
            }

            _context.Entry(clinician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicianExists(id))
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

        // POST: api/Clinicians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clinician>> PostClinician(Clinician clinician)
        {
            _context.Clinicians.Add(clinician);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClinicianExists(clinician.RegistrationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClinician", new { id = clinician.RegistrationID }, clinician);
        }

        // DELETE: api/Clinicians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinician(string id)
        {
            var clinician = await _context.Clinicians.FindAsync(id);
            if (clinician == null)
            {
                return NotFound();
            }

            _context.Clinicians.Remove(clinician);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClinicianExists(string id)
        {
            return _context.Clinicians.Any(e => e.RegistrationID == id);
        }
    }
}
*/