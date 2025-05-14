using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
     public class clsApplication
    {
        public enum enApplicationType { NewLocalDrivingLicenseService =1 , RenewDrivingLicenseService = 2, ReplacementForALostDrivingLicense =3 ,
            ReplacementForADamagedDrivingLicense = 4 , ReleaseDetainedDrivingLicense = 5 , NewInternationalLicense = 6 , RetakeTest = 7
        };
        public enum enStatus { New = 1 , Cancelled =2 , Completed = 3};
        public enum en_Mode { UpdateMode = 0, AddNewMode = 1 };
        public en_Mode Mode = en_Mode.AddNewMode;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public Person PersonInfo { get { return Person.FindPerson(this.ApplicantPersonID); } }
        public string ApplicationPersonFullName
        {
            get
            {
                return Person.FindPerson(ApplicantPersonID).FullName;
            }
        }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public ApplicationType applicationType
        {
            get
            {
                return ApplicationType.FindApplicationTypeByID(ApplicationTypeID);
            }
        }
        public enStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case (enStatus.New):
                        return "New";
                        break;
                    case (enStatus.Cancelled):
                        return "Cancelled";
                        break;
                    case (enStatus.Completed):
                        return "Completed";
                        break;
                    default:
                        return "Unknown";
                        break;
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public User CreatedByUserInfo
        {
            get
            {
                return User.FindUserByUserID(CreatedByUserID);
            }
        }

        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;

            Mode = en_Mode.AddNewMode;
        }

        private clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID,
            byte applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = (enStatus)applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;

            Mode = en_Mode.UpdateMode;
        }

        static public clsApplication FindApplication(int applicationID)
        {
            int applicantPersonID = default;
            DateTime applicationDate = default;
            int applicationTypeID = default;
            byte applicationStatus = default;
            DateTime lastStatusDate = default;
            float paidFees = default;
            int createdByUserID = default;

            if (Applications.FindApplication(applicationID, ref applicantPersonID, ref applicationDate,
                ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
            {
                return new clsApplication(applicationID, applicantPersonID, applicationDate, applicationTypeID,
                    applicationStatus, lastStatusDate, paidFees, createdByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _UpdateApplication()
        {
            return Applications.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        private bool _AddApplication()
        {
            ApplicationID = Applications.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID,(byte) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (ApplicationID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return _UpdateApplication();
                case en_Mode.AddNewMode:
                    if (_AddApplication())
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

        static public bool DeleteApplication(int applicationID)
        {
            return Applications.DeleteApplication(applicationID);
        }

        static public DataTable GetAllApplications()
        {
            return Applications.GetAllApplications();
        }

        static public bool IsApplicationExist(int applicationID)
        {
            return Applications.IsApplicationExist(applicationID);
        }

        public static int GetActiveApplicationForLicenseClass(int applicationPersonID, enApplicationType applicationType, int licenseClassID) =>
            Applications.GetActiveApplicationForLicenseClass(applicationPersonID, (int) applicationType, licenseClassID);

        public static bool UpdateStatus(int applicationID, byte newStatus) =>
            Applications.UpdateStatus(applicationID, newStatus);
        public bool CancelApplication() => UpdateStatus(ApplicationID , (byte)enStatus.Cancelled);

        public bool CompleteApplication() => UpdateStatus(ApplicationID, (byte)enStatus.Completed);


    }
}
