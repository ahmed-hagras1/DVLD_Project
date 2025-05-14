using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business_Layer
{
    public  class InternationalLicense : clsApplication
    {
        enum enMode { UpdateMode = 0 , AddNewMode =1 }
        enMode _Mode = enMode.AddNewMode;

        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public Driver DriverInfo
        {
            get { return Driver.FindDriver(DriverID); }
        }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public InternationalLicense()
        {
            _Mode = enMode.AddNewMode;
            InternationalLicenseID = ApplicationID = DriverID = IssuedUsingLocalLicenseID = CreatedByUserID = -1;
            IssueDate = ExpirationDate = DateTime.Now;
            IsActive = false;
        }
        private InternationalLicense(int internationalLicenseID , int applicationID , int driverID , int issuedUsingLocalLicenseID ,DateTime issueDate , 
            DateTime expirationDate , bool isActive , int createdByUserID, int personID , DateTime applicationDate, enApplicationType applicationType , 
            enStatus applicationStatus ,DateTime lastStatusDate, float paidFees )
        {
            _Mode = enMode.UpdateMode;

            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;
            this.ApplicantPersonID = personID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = (int) applicationType;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
        }

        public static InternationalLicense FindInternationalLicense(int internationalLicenseID)
        {
            int applicationID = -1, driverID = -1, issuedUsingLocalLicenseID = -1 , createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false ;


            if (InternationalLicenses.FindInternationalLicense(internationalLicenseID , ref applicationID , ref driverID , ref issuedUsingLocalLicenseID , ref issueDate,
                ref expirationDate , ref  isActive , ref createdByUserID))
            {
                clsApplication application = clsApplication.FindApplication(applicationID);

                return new InternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate,
                    expirationDate, isActive, createdByUserID, application.ApplicantPersonID, application.ApplicationDate,(enApplicationType) application.ApplicationTypeID,
                    application.ApplicationStatus, application.LastStatusDate, application.PaidFees);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID =  InternationalLicenses.AddNewInternationalLicense
            (this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense() => InternationalLicenses.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID,
            this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        
        public bool Save()
        {
            base.Mode = (clsApplication.en_Mode)this._Mode;
            if (!base.Save())
                return false;

            switch (_Mode)
            {
                case enMode.UpdateMode:
                    return _UpdateInternationalLicense();
                    break;
                case enMode.AddNewMode:
                    if (_AddNewInternationalLicense())
                    {
                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                        return false;
                        break;
                default:
                    return false;   
                    break;
            }
        }
        public static int GetActiveInternationalLicenseIDByDriverID(int driverID) => InternationalLicenses.GetActiveInternationalLicenseIDByDriverID(driverID);
        public static bool DeleteInternationalLicense(int internationalLicenseID) => InternationalLicenses.DeleteInternationalLicense(internationalLicenseID);
        public static DataTable GetAllInternationalLicense() => InternationalLicenses.GetAllInternationalLicenses();
        public static DataTable GetAllInternationalLicensesOwnedByDriver(int driverID) => InternationalLicenses.GetAllInternationalLicensesOwnedByDriver(driverID);
        public static bool IsInternationalLicenseExist(int internationalLicenseID) => InternationalLicenses.IsInternationalLicenseExist(internationalLicenseID);
    }
}
