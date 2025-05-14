using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Person
    {
        public enum en_Mode { UpdateMode = 0 , AddNewMode = 1};
        public en_Mode Mode = en_Mode.AddNewMode;
        public int personID { get; set; }
        public string nationalNo { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string lastName { get; set; }
        public string FullName
        {
            get { return firstName + ' ' + secondName + ' ' + thirdName + ' ' + lastName + ' '; }
        }
        public DateTime dateOfBirth { get; set; }
        public byte gender { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int nationalCountryID { get; set; }
        public string ImagePath { get; set; }
        public Country countryInfo { get; set; }
        public Person()
        {
            personID = -1;
            nationalNo = "";
            firstName = "";
            secondName = "";
            thirdName = "";
            lastName = "";
            dateOfBirth = DateTime.Now;
            gender = 0;
            address = "";
            phone = "";
            email = "";
            nationalCountryID = -1;
            ImagePath = "";

            Mode = en_Mode.AddNewMode;
        }

        private Person(int personID ,string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, DateTime dateOfBirth, byte gender,
            string address, string phone, string email, int nationalCountryID, string imagePath)
        {
            this.personID = personID;
            this.nationalNo = nationalNo;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.nationalCountryID = nationalCountryID;
            this.ImagePath = imagePath;
            this.countryInfo = Country.FindCountry(this.nationalCountryID);

            Mode = en_Mode.UpdateMode;
        }

        static public Person FindPerson(int personID)
        {
            string nationalNo = default, firstName = default, secondName = default, thirdName = default,
                   lastName = default;
            DateTime dateOfBirth = default;
            byte gender = default;
            string address = default , phone = default , email = default;
            int nationalCountryID = default;
            string imagePath = default;

            if (PeopleDataAccess.FindPerson(personID,ref nationalNo , ref firstName, ref secondName , 
                ref thirdName,ref lastName , ref dateOfBirth, ref gender , ref address ,
                ref phone , ref email , ref nationalCountryID , ref imagePath))
            {
                return new Person(personID,nationalNo, firstName, secondName, thirdName, lastName, dateOfBirth, gender,
                    address, phone, email, nationalCountryID, imagePath);
            }
            else
            {
                return null;
            }
        }

        static public Person FindPerson(string nationalNo )
        {
            int personID = default;
            string  firstName = default, secondName = default, thirdName = default,
                   lastName = default;
            DateTime dateOfBirth = default;
            byte gender = default;
            string address = default, phone = default, email = default;
            int nationalCountryID = default;
            string imagePath = default;

            if (PeopleDataAccess.FindPerson(nationalNo ,ref personID , ref firstName, ref secondName,
                ref thirdName, ref lastName, ref dateOfBirth, ref gender, ref address,
                ref phone, ref email, ref nationalCountryID, ref imagePath))
            {
                return new Person(personID,nationalNo, firstName, secondName, thirdName, lastName, dateOfBirth,
                    gender,address, phone, email, nationalCountryID, imagePath);
            }
            else
            {
                return null;
            }
        }

        private bool _UpdatePerson()
        {
            return PeopleDataAccess.UpdatePerson(this.personID, this.nationalNo, this.firstName, this.secondName,
                this.thirdName,this.lastName, this.dateOfBirth, this.gender,
                this.address, this.phone, this.email, this.nationalCountryID, this.ImagePath);
        }

        private bool _AddPerson()
        {
            personID = PeopleDataAccess.AddNewPerson(this.nationalNo, this.firstName, this.secondName,
                this.thirdName, this.lastName, this.dateOfBirth, this.gender, this.address,
                this.phone, this.email, this.nationalCountryID, this.ImagePath);

            return (personID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return _UpdatePerson();
                    break;
                case en_Mode.AddNewMode:
                    if (_AddPerson())
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
        static public bool DeletePerson(int personID)
        {
            return PeopleDataAccess.DeletePerson(personID);
        }
        static public DataTable GetAllPeople()
        {
            return PeopleDataAccess.GetAllPeople();
        }

        static public bool IsPersonExist(int personID)
        {
            return PeopleDataAccess.IsPersonExist(personID);
        }
        static public bool IsPersonExist(string nationalNo)
        {
            return PeopleDataAccess.IsPersonExist(nationalNo);
        }
    }
}
