README

This project's purpose is to create a Medication Request.
In addition to the description of the entities I added identity to Patient entity.
For code system of medication better to use enums but I don't have the values.

If I were to have more time:
	I would have added validation to end date of prescription not earlier than start date.
	I would have investigated why parameters of the POST controller are empty.
	I would have added autoMapping instead of manual mapping from MedicationRequest to MedicationPrescriptionResponse to use in MedicationRequestsController Get controller
	I would have added more summaries and description of actions and parameters inside ///
	I would have improve successful reponse to Patch action
	I didn't have enough time to
		add  Unit tests for update medication request and for getting medication request per status and date range
	    Containerizing the app in Docker
	Just after I finish implementation I notice that I was suppose to make incremental check-ins with comments to the Git repo as would be done in real
	development. so I just commited once.

CONTACT
	Any question please contact: haddas613@gmail.com

INSTALLATION
	Microsoft.AspNet.OData
RUNNING
	to run unit test need to start new debug instance for UnitTestPatientMedicationMoq and UnitTestPatientMedication
	then open Test -> Test Explorer an run the tests there. 
