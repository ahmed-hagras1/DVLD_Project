using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class LocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode { UpdateMode = 0, AddNewMode = 1 };
        public enMode Mode { get; set; } = enMode.AddNewMode;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public string LicenseClassName
        {
            get { return LicenseClass.FindLicenseClass(LicenseClassID).ClassName; }
        }
        public LicenseClass licenseClassInfo;
        public string FullName
        {
            get { return base.PersonInfo.FullName; }
        }
        public LocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
           
            Mode = enMode.AddNewMode;
        }

        private LocalDrivingLicenseApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID,
             int applicationPersonID, DateTime applicationDate , int applicationType, enStatus applicationStatus,DateTime lastStatusDate, 
             float paidFees , int createdByUserID )
        {
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.ApplicationID = applicationID;
            this.LicenseClassID = licenseClassID;
            this.licenseClassInfo = LicenseClass.FindLicenseClass(licenseClassID);
            this.ApplicantPersonID = applicationPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationType;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;

            Mode = enMode.UpdateMode;
        }

        // Find Local Driving License Application
        static public LocalDrivingLicenseApplication FindLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID)
        {
            int applicationID = -1;
            int licenseClassID = -1;

            if (LocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID))
            {
                clsApplication application = clsApplication.FindApplication(applicationID);

                return new LocalDrivingLicenseApplication(localDrivingLicenseApplicationID, applicationID, licenseClassID, application.ApplicantPersonID,
                    application.ApplicationDate, application.ApplicationTypeID,(enStatus) application.ApplicationStatus, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        static public LocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationByApplicationID(int applicationID)
        {
            int localDrivingLicenseApplicationID = default;
            int licenseClassID = default;

            if (LocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByApplicationID(applicationID, ref localDrivingLicenseApplicationID, ref licenseClassID))
            {
                clsApplication application = clsApplication.FindApplication(applicationID);

                return new LocalDrivingLicenseApplication(localDrivingLicenseApplicationID, applicationID, licenseClassID, application.ApplicantPersonID,
                    application.ApplicationDate, application.ApplicationTypeID, (enStatus)application.ApplicationStatus, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        // Update Local Driving License Application
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return LocalDrivingLicenseApplications.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }

        // Add New Local Driving License Application
        private bool _AddLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return (LocalDrivingLicenseApplicationID != -1);
        }

        // Save Local Driving License Application
        public bool Save()
        {
            // if Mode add new then Mode in base class will be add new, Update mode same.
            base.Mode = (clsApplication.en_Mode)this.Mode;
            // will update or add new in base class first.
            if (!base.Save())
                return false;

            // and update or add new in sub class.
            switch (Mode)
            {
                case enMode.UpdateMode:
                    return _UpdateLocalDrivingLicenseApplication();
                case enMode.AddNewMode:
                    if (_AddLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.UpdateMode;
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

        // Delete Local Driving License Application
        static public bool DeleteLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID)
        {
           int applicationID =  LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(localDrivingLicenseApplicationID).ApplicationID;

            return (LocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplication(localDrivingLicenseApplicationID) &&
                clsApplication.DeleteApplication(applicationID));

        }

        // Get All Local Driving License Applications
        static public DataTable GetAllLocalDrivingLicenseApplications() => LocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();

        // Check if Local Driving License Application Exists
        static public bool IsLocalDrivingLicenseApplicationExist(int localDrivingLicenseApplicationID)
        {
            return LocalDrivingLicenseApplications.IsLocalDrivingLicenseApplicationExist(localDrivingLicenseApplicationID);
        }

        public bool DoesPassTestType(TestType.en_TestType testTypeID) =>
            LocalDrivingLicenseApplications.DoesPassTestType(this.LocalDrivingLicenseApplicationID,(int) testTypeID);
        public bool DoesPassAllTests()
        {
            return (Test.GetPassedTestCount(this.LocalDrivingLicenseApplicationID) == 3 );
        }
        public static bool DoesPassTestType(int localDrivingLicenseApplicationID, TestType.en_TestType testType) => 
            LocalDrivingLicenseApplications.DoesPassTestType(localDrivingLicenseApplicationID, (int)testType);
        public static bool DoesAttendTestType(int localDrivingLicenseApplicationID, TestType.en_TestType testTypeID) =>
            LocalDrivingLicenseApplications.DoesAttendTestType(localDrivingLicenseApplicationID, (int)testTypeID);
        public bool DoesAttendTestType( TestType.en_TestType testTypeID) =>
            LocalDrivingLicenseApplications.DoesAttendTestType(this.LocalDrivingLicenseApplicationID,(int)testTypeID);
        public static byte TotalTrialsPerTest(int localDrivingLicenseApplicationID, TestType.en_TestType testTypeID) =>
            LocalDrivingLicenseApplications.TotalTrialsPerTest(localDrivingLicenseApplicationID,(int) testTypeID);
        public byte TotalTrialsPerTest( TestType.en_TestType testTypeID) =>
            LocalDrivingLicenseApplications.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)testTypeID);
        public static bool IsThereAnActiveScheduledTest(int localDrivingLicenseApplicationID, int testTypeID) =>
            LocalDrivingLicenseApplications.IsThereAnActiveScheduledTest(localDrivingLicenseApplicationID, testTypeID);
        public  bool IsThereAnActiveScheduledTest( int testTypeID) =>
            LocalDrivingLicenseApplications.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, testTypeID);
        public int GetActiveLicenseID() => clsLicense.GetActiveLicenseIDByPerson(this.ApplicantPersonID, this.LicenseClassID);
        public int GetLicenseIDByApplicationID () => clsLicense.GetLicenseIDByApplicationID(this.ApplicationID);
        public bool IsLicenseIssued() => (GetLicenseIDByApplicationID() != -1);
        public int IssueLicenseForTheFirstTime(string notes , int createdByUserID )
        {
            Driver driver = Driver.FindDriverByPersonID(this.ApplicantPersonID);

            if(driver == null)
            {
                driver = new Driver();

                driver.PersonID = this.ApplicantPersonID;
                driver.CreatedByUserID = createdByUserID;
                driver.CreatedDate = DateTime.Now;

                if (!driver.Save())
                    return -1;
            }

            clsLicense license = new clsLicense();

            license.ApplicationID = this.ApplicationID;
            license.DriverID = driver.DriverID;
            license.LicenseClassID = this.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(this.licenseClassInfo.DefaultValidityLength);
            license.Notes = notes;
            license.PaidFees = licenseClassInfo.ClassFees;
            license.IsActive = true;
            license.IssueReason = clsLicense.enIssueReason.firstTime;
            license.CreatedByUserID = createdByUserID;

            if (license.Save())
            {
                // Update the application status to completed.
                this.CompleteApplication();
               
                return license.LicenseID;
            }
            else
            {
                return -1;
            }
        }
    }

}
