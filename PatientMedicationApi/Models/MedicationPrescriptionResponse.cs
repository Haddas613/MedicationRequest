using System.Collections.Generic;
using System.Xml.Linq;

namespace PatientMedicationApi.Models
{
    public class MedicationPrescriptionResponse : MedicationRequest
    {
        public string MedicationName { get; set; }
        public string ClinicianFirstName { get; set; }
        public string ClinicianLastName { get; set; }
    }
}
