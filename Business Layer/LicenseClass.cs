using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class LicenseClass
    {
        public enum en_Mode { UpdateMode = 0, AddNewMode = 1 };
        public en_Mode Mode { get; set; } = en_Mode.AddNewMode;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        // Default constructor for AddNewMode
        public LicenseClass()
        {
            LicenseClassID = -1;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;

            Mode = en_Mode.AddNewMode;
        }

        // Private constructor for UpdateMode
        private LicenseClass(int licenseClassID, string className, string classDescription,
                                byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
            this.LicenseClassID = licenseClassID;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinimumAllowedAge = minimumAllowedAge;
            this.DefaultValidityLength = defaultValidityLength;
            this.ClassFees = classFees;

            Mode = en_Mode.UpdateMode;
        }

        // Find a LicenseClass by LicenseClassID
        static public LicenseClass FindLicenseClass(int licenseClassID)
        {
            string className = string.Empty;
            string classDescription = string.Empty;
            byte minimumAllowedAge = 0;
            byte defaultValidityLength = 0;
            float classFees = 0;

            if (LicenseClasses.FindLicenseClass(licenseClassID, ref className, ref classDescription,
                                                       ref minimumAllowedAge, ref defaultValidityLength, ref classFees))
            {
                return new LicenseClass(licenseClassID, className, classDescription,
                                          minimumAllowedAge, defaultValidityLength, classFees);
            }
            else
            {
                return null;
            }
        }
        static public LicenseClass FindLicenseClass(string licenseClassName)
        {
            int licenseClassID =0;
            string classDescription = string.Empty;
            byte minimumAllowedAge = 0;
            byte defaultValidityLength = 0;
            float classFees = 0;

            if (LicenseClasses.FindLicenseClass(licenseClassName, ref licenseClassID , ref classDescription , ref minimumAllowedAge , ref defaultValidityLength , ref classFees))
            {
                return new LicenseClass(licenseClassID, licenseClassName, classDescription,
                                          minimumAllowedAge, defaultValidityLength, classFees);
            }
            else
            {
                return null;
            }
        }

        // Update an existing LicenseClass
        private bool _UpdateLicenseClass() => LicenseClasses.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription,
                                                            this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

        // Add a new LicenseClass
        private bool _AddLicenseClass()
        {
            LicenseClassID = LicenseClasses.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                                                                      this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

            return (LicenseClassID != -1);
        }

        // Save the LicenseClass (Add or Update)
        public bool Save()
        {
            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return _UpdateLicenseClass();
                case en_Mode.AddNewMode:
                    if (_AddLicenseClass())
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

        // Delete a LicenseClass by LicenseClassID
        static public bool DeleteLicenseClass(int licenseClassID) => LicenseClasses.DeleteLicenseClass(licenseClassID);

        // Get all LicenseClasses
        static public DataTable GetAllLicenseClasses() => LicenseClasses.GetAllLicenseClasses();

        // Check if a LicenseClass exists by LicenseClassID
        static public bool IsLicenseClassExist(int licenseClassID) => LicenseClasses.IsLicenseClassExist(licenseClassID);
    }
}
