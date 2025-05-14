using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class DetainedLicense
    {
        public enum en_Mode { UpdateMode = 0 , AddNewMode =1 }
        public en_Mode Mode = en_Mode.AddNewMode;
         
        public int detainedID { get; set; }
        public int licenseID { get; set; }
        public DateTime detainDate { get; set; }
        public float fineFees { get; set; }
        public int createdByUserID { get; set; }
        // Composition.
        public User createdByUserInfo { get; set; }
        public bool isReleased { get; set; }
        public DateTime releaseDate { get; set; }
        public int releasedByUserID { get; set; }
        // Composition.
        public User releasedByUserInfo { get; set; }
        public int releasedApplicationID { get; set; }

        public DetainedLicense()
        {
            detainedID = -1;
            licenseID = -1;
            detainDate = DateTime.Now;
            fineFees = 0f;
            createdByUserID = -1;
            isReleased = false;
            releaseDate = DateTime.MaxValue;
            releasedByUserID = -1;
            releasedApplicationID = -1;

            Mode = en_Mode.AddNewMode;
        }

        private DetainedLicense(int detainedID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID,
            bool isReleased, DateTime releaseDate, int releasedByUserID, int releasedApplicationID)
        {
            this.detainedID = detainedID;
            this.licenseID = licenseID;
            this.detainDate = detainDate;
            this.fineFees = fineFees;
            this.createdByUserID = createdByUserID;
            this.createdByUserInfo = User.FindUserByUserID(this.createdByUserID);
            this.isReleased = isReleased;
            this.releaseDate = releaseDate;
            this.releasedByUserID = releasedByUserID;
            this.releasedByUserInfo = User.FindUserByUserID(this.createdByUserID);
            this.releasedApplicationID = releasedApplicationID;

            Mode = en_Mode.UpdateMode;
        }

        private bool _AddNewDetainedLicense()
        {
            detainedID = DetainedLicenses.AddNewDetainedLicense(licenseID, detainDate, fineFees, createdByUserID);

            return (detainedID != -1);
        }
        private bool _UpdatedDetainedLicense() => DetainedLicenses.UpdateDetainedLicense(detainedID, licenseID, detainDate, fineFees, createdByUserID);
        public bool Save()
        {
            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return _UpdatedDetainedLicense();
                    break;
                case en_Mode.AddNewMode:
                    if (_AddNewDetainedLicense())
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
        public static DetainedLicense FindDetainedLicenseByID(int detainID)
        {
            int licenseId = -1, createdByUserID = -1, releasedByUserID = -1, releasedApplicationID = -1;
            DateTime detainDate = DateTime.Now, releaseDate = DateTime.MaxValue;
            float fineFees = 0;
            bool isReleased = false;

            if (DetainedLicenses.FindDetainedLicenseInfoByID(detainID, ref licenseId, ref detainDate, ref fineFees,
                ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releasedApplicationID))
                return new DetainedLicense(detainID, licenseId, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releasedApplicationID);
            else
                return null;
        }
        public static DetainedLicense FindDetainedLicenseByLicenseID(int licenseId)
        {
            int detainID = -1, createdByUserID = -1, releasedByUserID = -1, releasedApplicationID = -1;
            DateTime detainDate = DateTime.Now, releaseDate = DateTime.MaxValue;
            float fineFees = 0;
            bool isReleased = false;

            if (DetainedLicenses.FindDetainedLicenseInfoByLicenseID(licenseId, ref detainID, ref detainDate, ref fineFees,
                ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releasedApplicationID))
                return new DetainedLicense(detainID, licenseId, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releasedApplicationID);
            else
                return null;
        }
        public static DataTable GetAllDetainedLicenses() => DetainedLicenses.GetAllDetainedLicenses();
        public static bool ReleaseDetainedLicense(int detainID, int releasedByUserID, int releaseApplicationID) 
            => DetainedLicenses.ReleaseDetainedLicense(detainID, releasedByUserID, releaseApplicationID);
        public static bool IsLicenseDetained(int licenseID) => DetainedLicenses.IsLicenseDetained(licenseID);
    }
}
