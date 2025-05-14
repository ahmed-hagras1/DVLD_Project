using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class ApplicationType
    {
        enum en_Mode { UpdateMode = 0 , AddNewMode = 1 };
        en_Mode Mode = en_Mode.AddNewMode;
        public int applicationTypeID { get; set; }
        public string applicationTypeTitle { get; set; }
        public float applicationTypeFees { get; set; }

        public ApplicationType()
        {
            this.applicationTypeID = default;
            this.applicationTypeTitle = default;
            this.applicationTypeFees= default;
            Mode = en_Mode.AddNewMode;
        }

        private ApplicationType(int applicationTypeID, string applicationTypeTitle , float applicationTypeFees)
        {
            this.applicationTypeID = applicationTypeID;
            this.applicationTypeTitle = applicationTypeTitle;
            this.applicationTypeFees = applicationTypeFees;
            Mode = en_Mode.UpdateMode;
        }
        public static DataTable GetAllApplicationTypes()
        {
            return ApplicationTypes.GetAllApplicationTypes();
        }
        public static ApplicationType FindApplicationTypeByID(int applicationTypeID )
        {
            string applicationTypeTitle = "";
            float applicationTypeFees = 0;

            if (ApplicationTypes.FindApplicationTypeByID(applicationTypeID, ref applicationTypeTitle, ref applicationTypeFees))
                return new ApplicationType(applicationTypeID, applicationTypeTitle, applicationTypeFees);
            else
                return null;

        }

        private bool UpdateApplicationType() => ApplicationTypes.UpdateApplicationType(applicationTypeID, applicationTypeTitle, applicationTypeFees);
        private bool AddNewApplicationType()
        {
            return (ApplicationTypes.AddNewApplicationType(applicationTypeTitle , applicationTypeFees) != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return UpdateApplicationType();
                    break;
                case en_Mode.AddNewMode:
                    if (AddNewApplicationType())
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

        public static bool IsApplicationTypeExist(int applicationTypeID)
        {
            return ApplicationTypes.IsApplicationTypeExist(applicationTypeID);
        }
        public static bool IsApplicationTypeExist(string applicationTypeTitle)
        {
            return ApplicationTypes.IsApplicationTypeExist(applicationTypeTitle);
        }

    }
}
