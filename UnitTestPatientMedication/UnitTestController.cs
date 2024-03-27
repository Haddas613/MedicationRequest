using Moq;
using PatientMedicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestPatientMedicationMoq.Controllers;
using UnitTestPatientMedicationMoq.Services;

namespace UnitTestPatientMedication
{
    public class UnitTestController
    {
        private readonly Mock<IMedicationRequestService> medicationRequestService;
        public UnitTestController()
        {
            medicationRequestService = new Mock<IMedicationRequestService>();
        }
        [Fact]
        public void GetMedicationRequestList_MedicationRequestList()
        {
            //arrange
            var medicationRequestList = GetMedicationRequestsData();
            medicationRequestService.Setup(x => x.GetMedicationRequestList())
                .Returns(medicationRequestList);
            var medicationRequestController = new MedicationRequestController(medicationRequestService.Object);
            //act
            var medicationRequestsResult = medicationRequestController.MedicationRequestList();
            //assert
            Assert.NotNull(medicationRequestsResult);
            Assert.Equal(GetMedicationRequestsData().Count(), medicationRequestsResult.Count());
            Assert.Equal(GetMedicationRequestsData().ToString(), medicationRequestsResult.ToString());
            Assert.True(medicationRequestList.Equals(medicationRequestsResult));
        }

        [Fact]
        public void AddMedicationRequest()
        {
            //arrange
            var medicationRequestList = GetMedicationRequestsData();
            medicationRequestService.Setup(x => x.AddMedicationRequest(medicationRequestList[2]))
                .Returns(medicationRequestList[2]);
            var medicationRequestController = new MedicationRequestController(medicationRequestService.Object);
            //act
            var medicationRequestResult = medicationRequestController.AddMedicationRequest(medicationRequestList[2]);
            //assert
            Assert.NotNull(medicationRequestResult);
            Assert.Equal(medicationRequestList[2].ClinicianRegistrationID, medicationRequestResult.ClinicianRegistrationID);
            Assert.True(medicationRequestList[2].ClinicianRegistrationID == medicationRequestResult.ClinicianRegistrationID);

            Assert.Equal(medicationRequestList[2].MedicationCode, medicationRequestResult.MedicationCode);
            Assert.True(medicationRequestList[2].MedicationCode == medicationRequestResult.MedicationCode);

            Assert.Equal(medicationRequestList[2].PatientIdentity, medicationRequestResult.PatientIdentity);
            Assert.True(medicationRequestList[2].PatientIdentity == medicationRequestResult.PatientIdentity);
        }
        
        private List<MedicationRequest> GetMedicationRequestsData()
        {
            List<MedicationRequest> medicationRequestsData = new List<MedicationRequest>
        {
            new MedicationRequest
            {
                  ClinicianRegistrationID = "crabc",
                   Frequency =  new Frequency{  Amount=1, UnitTime = PatientMedicationApi.Enums.UnitTime.Day},
                    EndDate = DateTime.Now.AddDays(30),
                     MedicationCode = "mcabc",
                      PatientIdentity = "204342265",
                       Reason = "illness",
                        StartDate = DateTime.Now.AddDays(1),
                         Status = PatientMedicationApi.Enums.PrescriptionStatus.Active
            },
             new MedicationRequest
            {
                 ClinicianRegistrationID = "crdef",
                   Frequency =  new Frequency{  Amount=2, UnitTime = PatientMedicationApi.Enums.UnitTime.Day},
                    EndDate = DateTime.Now.AddDays(60),
                     MedicationCode = "mcdef",
                      PatientIdentity = "204342265",
                       Reason = "illness",
                        StartDate = DateTime.Now.AddDays(2),
                         Status = PatientMedicationApi.Enums.PrescriptionStatus.Active
            },
             new MedicationRequest
            {
                ClinicianRegistrationID = "crghi",
                   Frequency =  new Frequency{  Amount=3, UnitTime = PatientMedicationApi.Enums.UnitTime.Day},
                    EndDate = DateTime.Now.AddDays(30),
                     MedicationCode = "mcghi",
                      PatientIdentity = "204342265",
                       Reason = "illness",
                        StartDate = DateTime.Now.AddDays(3),
                         Status = PatientMedicationApi.Enums.PrescriptionStatus.Active
            },
        };
            return medicationRequestsData;
        }
    }
}