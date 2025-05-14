using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Driver
    {

        public enum en_Mode { UpdateMode = 0, AddNewMode = 1 };

            public en_Mode Mode = en_Mode.AddNewMode;
            public int DriverID { get; set; }
            public int PersonID { get; set; }
            public int CreatedByUserID { get; set; }
            public DateTime CreatedDate { get; set; }

            // Navigation properties
            // Composition.
           public Person PersonInfo { get; set; }
       
            public User CreatedByUserInfo { get; set; }

            public Driver()
            {
                DriverID = -1;
                PersonID = -1;
                CreatedByUserID = -1;
                CreatedDate = DateTime.Now;
                Mode = en_Mode.AddNewMode;
            }

            private Driver(int driverID, int personID, int createdByUserID, DateTime createdDate)
            {
                this.DriverID = driverID;
                this.PersonID = personID;
                this.CreatedByUserID = createdByUserID;
                this.CreatedDate = createdDate;
                this.PersonInfo = Person.FindPerson(personID);
                this.CreatedByUserInfo = User.FindUserByUserID(createdByUserID);

                Mode = en_Mode.UpdateMode;
            }

            static public Driver FindDriver(int driverID)
            {
                int personID = default;
                int createdByUserID = default;
                DateTime createdDate = default;

                if (Drivers.FindDriver(driverID, ref personID, ref createdByUserID, ref createdDate))
                {
                    return new Driver(driverID, personID, createdByUserID, createdDate);
                }
                else
                {
                    return null;
                }
            }

            static public Driver FindDriverByPersonID(int personID)
            {
                int driverID = default;
                int createdByUserID = default;
                DateTime createdDate = default;

                if (Drivers.FindDriverByPersonID(personID, ref driverID, ref createdByUserID, ref createdDate))
                {
                    return new Driver(driverID, personID, createdByUserID, createdDate);
                }
                else
                {
                    return null;
                }
            }

            private bool _UpdateDriver()
            {
                return Drivers.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
            }

            private bool _AddDriver()
            {
                DriverID = Drivers.AddNewDriver(this.PersonID, this.CreatedByUserID);
                return (DriverID != -1);
            }

            public bool Save()
            {
                switch (Mode)
                {
                    case en_Mode.UpdateMode:
                        return _UpdateDriver();
                    case en_Mode.AddNewMode:
                        if (_AddDriver())
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

            static public bool DeleteDriver(int driverID) => Drivers.DeleteDriver(driverID);
            static public DataTable GetAllDrivers() => Drivers.GetAllDrivers();

            static public bool IsDriverExist(int driverID) => Drivers.IsDriverExist(driverID);

            static public bool IsDriverExistByPersonID(int personID) => Drivers.IsDriverExistByPersonID(personID);

        public static DataTable GetLicenses (int driverID) =>  Licenses.GetAllLicensesOwnedByDriver(driverID);
        public static DataTable GetInternationalLicenses(int driverID) => InternationalLicenses.GetAllInternationalLicensesOwnedByDriver(driverID);
    }
}
