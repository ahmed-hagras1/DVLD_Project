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
    public class clsLicense
    {
        public enum enIssueReason { firstTime = 1, Renew = 2, damagedReplacement = 3, lostReplacement = 4 };
        public enum enLicenseStatus { Active = 1, Expired = 2, Revoked = 3 };

        enum en_Mode { UpdateMode = 0, AddNewMode = 1 };
        en_Mode Mode = en_Mode.AddNewMode;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public Driver DriverInfo
        {
            get
            {
                return Driver.FindDriver(DriverID);
            }
        }
        public int LicenseClassID { get; set; }
        public LicenseClass LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public bool IsLicenseDetained
        {
            get 
            {
                return DetainedLicense.IsLicenseDetained(LicenseID);
            }
        }
        public DetainedLicense DetainedLicenseInfo
        {
            get { return DetainedLicense.FindDetainedLicenseByLicenseID(this.LicenseID); }
        }
        public string IssueReasonText
        {
            get
            {
                return _GetIssueReasonText(this.IssueReason);
            }
        }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = -1;

            Mode = en_Mode.AddNewMode;
        }

        private clsLicense(int licenseID, int applicationID, int driverID, int licenseClass,
                           DateTime issueDate, DateTime expirationDate, string notes,
                           float paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.LicenseClassID = licenseClass;
            this.LicenseClassInfo = LicenseClass.FindLicenseClass(this.LicenseClassID);
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;

            Mode = en_Mode.UpdateMode;
        }

        static public clsLicense FindLicense(int licenseID)
        {
            int applicationID = default;
            int driverID = default;
            int licenseClass = default;
            DateTime issueDate = default;
            DateTime expirationDate = default;
            string notes = default;
            float paidFees = default;
            bool isActive = default;
            byte issueReason = default;
            int createdByUserID = default;

            if (Licenses.FindLicense(licenseID, ref applicationID, ref driverID, ref licenseClass,
                                     ref issueDate, ref expirationDate, ref notes, ref paidFees,
                                     ref isActive, ref  issueReason, ref createdByUserID))
            {
                return new clsLicense(licenseID, applicationID, driverID, licenseClass,
                                      issueDate, expirationDate, notes, paidFees, isActive,
                                      (enIssueReason) issueReason, createdByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _UpdateLicense()
        {
            return Licenses.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID,
                                         this.LicenseClassID, this.IssueDate, this.ExpirationDate,
                                         this.Notes, this.PaidFees, this.IsActive, (byte) this.IssueReason,
                                         this.CreatedByUserID);
        }

        private bool _AddLicense()
        {
            LicenseID = Licenses.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID,
                                              this.IssueDate, this.ExpirationDate, this.Notes,
                                              this.PaidFees, this.IsActive,(byte) this.IssueReason,
                                              this.CreatedByUserID);

            return (LicenseID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return _UpdateLicense();
                case en_Mode.AddNewMode:
                    if (_AddLicense())
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

        static public bool DeleteLicense(int licenseID)
        {
            return Licenses.DeleteLicense(licenseID);
        }

        static public DataTable GetAllLicenses()
        {
            return Licenses.GetAllLicenses();
        }
        static public bool IsLicenseExist(int licenseID)
        {
            return Licenses.IsLicenseExist(licenseID);
        }
        static public bool IsLicenseExistByPersonID(int personID, int licenseClassID) => (GetActiveLicenseIDByPerson(personID, licenseClassID) != -1);
        public static int GetActiveLicenseIDByPerson(int personID, int licenseClassID) => Licenses.GetActiveLicenseIDByPerson(personID, licenseClassID);
        public static int GetLicenseIDByApplicationID(int applicationID ) => Licenses.GetLicenseIDByApplicationID(applicationID);
        public static bool IsLicenseExistByPerson(int personID, int licenseClassID) => (GetActiveLicenseIDByPerson(personID, licenseClassID) != -1);
        static public bool DeActiveLicense(int licenseID) => Licenses.DeactivateLicense(licenseID);
        public bool DeActiveCurrentLicense() => Licenses.DeactivateLicense(this.LicenseID);
        private string _GetIssueReasonText (enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case enIssueReason.firstTime:
                    return "First time";
                    break;
                case enIssueReason.Renew:
                    return "Renew";
                    break;
                case enIssueReason.damagedReplacement:
                    return "Replacement for damaged";
                    break;
                case enIssueReason.lostReplacement:
                    return "Replacement for lost";
                    break;
                default:
                    return "First time";
                    break;
            }
        }
        public clsLicense RenewLicense(string notes,int createdByUserID)
        {
            clsApplication application = new clsApplication();

            application.ApplicantPersonID = DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicenseService;
            application.ApplicationStatus = clsApplication.enStatus.Completed;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = ApplicationType.FindApplicationTypeByID(application.ApplicationTypeID).applicationTypeFees;
            application.CreatedByUserID = createdByUserID;

            if (!application.Save())
                return null;

            clsLicense newLicense = new clsLicense();

            newLicense.ApplicationID = application.ApplicationID;
            newLicense.DriverID = DriverID;
            newLicense.LicenseClassID = LicenseClassID;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.DefaultValidityLength);
            newLicense.Notes = notes;
            newLicense.PaidFees = LicenseClassInfo.ClassFees;
            newLicense.IsActive = true;
            newLicense.IssueReason = enIssueReason.Renew;
            newLicense.CreatedByUserID = createdByUserID;

            if (!newLicense.Save())
                return null;

            // De active old license.
            DeActiveCurrentLicense();
           
            return newLicense;    

        }
        public clsLicense ReplacementLicense(clsApplication.enApplicationType applicationType , int createdByUserID)
        {
            clsApplication application = new clsApplication();

            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)applicationType;
            application.ApplicationStatus = clsApplication.enStatus.Completed;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = ApplicationType.FindApplicationTypeByID((int)applicationType).applicationTypeFees;
            application.CreatedByUserID = createdByUserID;

            if (!application.Save())
                return null;

            clsLicense newLicense = new clsLicense();

            newLicense.ApplicationID = application.ApplicationID;
            newLicense.DriverID = this.DriverID;
            newLicense.LicenseClassID = this.LicenseClassID;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = this.ExpirationDate;
            newLicense.Notes = this.Notes;
            newLicense.PaidFees = 0;
            newLicense.IsActive = true;
            newLicense.IssueReason = (applicationType == clsApplication.enApplicationType.ReplacementForADamagedDrivingLicense) ?
                enIssueReason.damagedReplacement : enIssueReason.lostReplacement;
            newLicense.CreatedByUserID = createdByUserID;

            if (!newLicense.Save())
                return null;

            DeActiveCurrentLicense();

            return newLicense;
        }
        public int DetainLicense(float fineFees , int createByUserID)
        {
           DetainedLicense detainedLicense = new DetainedLicense();

            detainedLicense.licenseID = this.LicenseID;
            detainedLicense.detainDate = DateTime.Now;
            detainedLicense.fineFees = fineFees;
            detainedLicense.createdByUserID = createByUserID;

            if (!detainedLicense.Save())
                return -1;

            return detainedLicense.detainedID;
        }
        public int ReleaseLicense(int detainID,int createdByUserID)
        {
            clsApplication application = new clsApplication();

            application.ApplicantPersonID = DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            application.ApplicationStatus = clsApplication.enStatus.Completed;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = ApplicationType.FindApplicationTypeByID(application.ApplicationTypeID).applicationTypeFees;
            application.CreatedByUserID = createdByUserID;

            if (!application.Save())
                return -1;

            DetainedLicense.ReleaseDetainedLicense(detainID, createdByUserID, application.ApplicationID);

            return application.ApplicationID;
        }
    }
}
