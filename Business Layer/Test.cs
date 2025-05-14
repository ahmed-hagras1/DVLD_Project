using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Test
    {

        enum en_Mode { UpdateMode = 0 , AddNewMode = 1 }
        en_Mode Mode = en_Mode.AddNewMode;

        public int testID { get; set; }
        public int testAppointmentID { get; set; }
        public TestAppointment testAppointmentInfo { get; set; }
        public int createdByUserID { get; set; }
        public bool testResult { get; set; }
        public string notes { get; set; }
        public Test()
        {
            testID = testAppointmentID = createdByUserID = 0;
            testResult = false;
            notes = "";

            Mode = en_Mode.AddNewMode;
        }
        private Test(int testID , int testAppointmentId , int createdByUserID , bool testResult , string notes)
        {
            this.testID = testID;
            this.testAppointmentID = testAppointmentId;
            this.testAppointmentInfo = TestAppointment.FindTestAppointment(testAppointmentId);
            this.createdByUserID = createdByUserID;
            this.testResult = testResult;
            this.notes = notes;

            Mode = en_Mode.UpdateMode;
        }

        public static Test FindTest (int testID)
        {
            int testAppointmentID = 0, createdByUserID = 0;
            bool testResult =false;
            string notes = "";

            if (Tests.FindTest(testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
                return new Test(testID, testAppointmentID, createdByUserID, testResult, notes);
            else
                return null;
        }
        public static Test FindLastTestByPersonAndTestTypeAndLicenseClass (int personID , TestType.en_TestType testType , int licenseClassID)
        {
            int testID = default , TestAppointmentID = default, createdByUserID = default;
            bool testResult =false;
            string notes = default;

            if (Tests.FindLastTestByPersonAndTestTypeAndLicenseClass(personID , (int)testType , licenseClassID , ref testID, ref TestAppointmentID , ref testResult , ref notes , ref createdByUserID))
                return new Test(testID , TestAppointmentID , createdByUserID , testResult , notes);
            else
                return null;
           
        } 
        public static Test FindTest (int personID, int testTypeID, int licenseClassId)
        {
            int testID = 0,testAppointmentID = 0, createdByUserID = 0;
            bool testResult = false ;
            string notes = "";

            if (Tests.FindLastTestByPersonAndTestTypeAndLicenseClass(personID , testTypeID , licenseClassId ,ref testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
                return new Test(testID, testAppointmentID, createdByUserID, testResult, notes);
            else
                return null;
        }
        public static DataTable GetAllTests() => Tests.GetAllTests();
        public static bool DeleteTest(int testID) => Tests.DeleteTest(testID);
        public static byte GetPassedTestCount(int localDrivingLicenseApplicationID) => Tests.GetPassedTestCount(localDrivingLicenseApplicationID);
        private bool _UpdateTest() =>
            Tests.UpdateTest(testID, testAppointmentID, testResult, notes, createdByUserID);
        private bool _AddNewTest()
        {
            this.testID = Tests.AddNewTest(testAppointmentID, testResult, notes, createdByUserID);

            return (testID != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return _UpdateTest();
                    break;
                case en_Mode.AddNewMode:
                    if (_AddNewTest())
                    {
                        Mode = en_Mode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                        break;
                default:
                    return false;
                    break;
            }
        }

    }
}
