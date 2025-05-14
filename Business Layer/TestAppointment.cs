using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class TestAppointment
    {

        public enum en_Mode { UpdateMode = 0, AddNewMode = 1 };

            public en_Mode Mode = en_Mode.AddNewMode;
            public int TestAppointmentID { get; set; }
            public TestType.en_TestType TestTypeID { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public DateTime AppointmentDate { get; set; }
            public float PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
            public bool IsLocked { get; set; }

        public int testID
        {
            get
            {
                return _GetTestID();
            }
        }
        public int RetakeTestAppID { get; set; }
        public clsApplication RetakeAppInfo { get; set; }

            public TestAppointment()
            {
                TestAppointmentID = -1;
                TestTypeID = TestType.en_TestType.VisionTest;
                LocalDrivingLicenseApplicationID = -1;
                AppointmentDate = DateTime.Now;
                PaidFees = 0;
                CreatedByUserID = -1;
                IsLocked = false;
                Mode = en_Mode.AddNewMode;

                RetakeTestAppID = -1;
                RetakeAppInfo = null;
            }

            private TestAppointment(int testAppointmentID, TestType.en_TestType testTypeID, int localDrivingLicenseApplicationID,
                                   DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked , int retakeTestApplicationID)
            {
                this.TestAppointmentID = testAppointmentID;
                this.TestTypeID = (TestType.en_TestType)testTypeID;
                this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
                this.AppointmentDate = appointmentDate;
                this.PaidFees = paidFees;
                this.CreatedByUserID = createdByUserID;
                this.IsLocked = isLocked;

                this.RetakeTestAppID=retakeTestApplicationID;
                this.RetakeAppInfo = clsApplication.FindApplication(retakeTestApplicationID);
                
                Mode = en_Mode.UpdateMode;
            }

            static public TestAppointment FindTestAppointment(int testAppointmentID)
            {
                int testTypeID = default;
                int localDrivingLicenseApplicationID = default;
                DateTime appointmentDate = default;
                float paidFees = default;
                int createdByUserID = default;
                bool isLocked = default;
                int retakeTestID = default;

            if (TestAppointments.FindTestAppointment(testAppointmentID, ref testTypeID,
                    ref localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees,
                    ref createdByUserID, ref isLocked , ref retakeTestID))
                {
                    return new TestAppointment(testAppointmentID,(TestType.en_TestType) testTypeID, localDrivingLicenseApplicationID,
                                              appointmentDate, paidFees, createdByUserID, isLocked , retakeTestID);
                }
                else
                {
                    return null;
                }
            }

        static public TestAppointment FindLastTestAppointment(int localDrivingLicenseApplicationID, int testTypeID)
        {
            int testAppointmentID = default;
            DateTime appointmentDate = default;
            float paidFees = default;
            int createdByUserID = default;
            bool isLocked = default;
            int retakeTestID = default;

            if (TestAppointments.FindLastTestAppointment(localDrivingLicenseApplicationID , testTypeID , ref testAppointmentID ,
                ref appointmentDate , ref paidFees , ref createdByUserID , ref isLocked , ref retakeTestID))
            {
                return new TestAppointment(testAppointmentID, (TestType.en_TestType)testTypeID, localDrivingLicenseApplicationID,
                                          appointmentDate, paidFees, createdByUserID, isLocked, retakeTestID);
            }
            else
            {
                return null;
            }
        }
        private bool _Update()
            {
                return TestAppointments.UpdateTestAppointment(
                    this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                    this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestAppID);
            }

            private bool _Add()
            {
                TestAppointmentID = TestAppointments.AddNewTestAppointment(
                    (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                    this.PaidFees, this.CreatedByUserID, this.IsLocked , this.RetakeTestAppID);

                return (TestAppointmentID != -1);
            }

            public bool Save()
            {
                switch (Mode)
                {
                    case en_Mode.UpdateMode:
                        return _Update();
                    case en_Mode.AddNewMode:
                        if (_Add())
                        {
                            Mode = en_Mode.UpdateMode;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    default:
                        return false;
                }
            }

            static public bool Delete(int testAppointmentID)
            {
                return TestAppointments.DeleteTestAppointment(testAppointmentID);
            }

            static public DataTable GetAllTestAppointments()
            {
                return TestAppointments.GetAllTestAppointments();
            }
        public static DataTable GetAllTestAppointmentsPerTestType(int localDrivingLicenseApplicationID, TestType.en_TestType testType) => 
            TestAppointments.GetAllTestAppointmentsPerTestType(localDrivingLicenseApplicationID , (int) testType);
            static public bool IsExist(int testAppointmentID)
            {
                return TestAppointments.IsTestAppointmentExist(testAppointmentID);
            }

            static public bool IsExistForApplication(int localDrivingLicenseApplicationID, int testTypeID)
            {
                return TestAppointments.IsTestAppointmentExistForApplication(
                    localDrivingLicenseApplicationID, testTypeID);
            }
        private int _GetTestID() => TestAppointments.GetTestID(this.TestAppointmentID);

    }
}
