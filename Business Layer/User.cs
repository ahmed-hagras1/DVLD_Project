using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class User
    {
        public enum en_Mode { UpdateMode = 0 , AddNewMode = 1};
        public en_Mode Mode = en_Mode.AddNewMode;
        public int userID { get; set; }
        public int personID { get; set; }
        public Person PersonInfo;
        public string username { get; set; }
        public string password { set; get; }
        public bool isActive { get; set; }

        public User()
        {
            Mode = en_Mode.AddNewMode;
            userID = -1;
            personID = -1;
            username = "";
            password = "";
            isActive = false;
        }
        private User( int userID, int personID, string username, string password, bool isActive)
        {
            Mode = en_Mode.UpdateMode;
            this.userID = userID;
            this.personID = personID;
            PersonInfo = Person.FindPerson(personID);
            this.username = username;
            this.password = password;
            this.isActive = isActive;
        }

        public static User FindUserByUserID(int userID)
        {
            int personID = default;
            string username = default, password = default;
            bool isActive = default;

            if (Users.FindUserByUserID(userID, ref personID, ref username, ref password, ref isActive))
                return new User(userID, personID, username, password, isActive);
            else
                return null;
            
        }
        public static User FindUserByPersonID(int personID)
        {
            int userID = default;
            string username = default, password = default;
            bool isActive = default;

            if (Users.FindUserByPersonID(personID, ref userID, ref username, ref password, ref isActive))
                return new User(userID, personID, username, password, isActive);
            else
                return null;

        }
        public static User FindUserByUsernameAndPassword(string username , string password)
        {
            int personID = default, userID = default;
            bool isActive = default;

            if (Users.FindUserByUsernameAndPassword(username, password, ref userID ,ref personID, ref isActive))
                return new User(userID, personID, username, password, isActive);
            else
                return null;

        }
        public static  bool DeleteUser(int userID)
        {
            return Users.DeleteUser(userID);
        }
        public static DataTable GetUsersList()
        {
            return Users.GetAllUsers();
        }
        private bool _AddNewUser()
        {
            userID =  Users.AddNewUser(personID, username, password, isActive);
            return (userID != -1);
        }
        private bool _UpdateUser ()
        {
            return Users.UpdateUser(userID, personID, username, password, isActive);
        }
        public bool Save()
        {

            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return _UpdateUser();
                    break;
                case en_Mode.AddNewMode:

                    if (_AddNewUser())
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

        public static bool IsUserExist(int userID)
        {
            return Users.IsUserExist(userID);
        }
        public static bool IsUserExist (string username)
        {
            return Users.IsUserExist(username);
        }
        public static bool IsUserExistByPersonID(int personID)
        {
            return Users.IsUserExistByPersonID(personID);
        }
        public bool ChangeUserPassword( string newPassword)
        {
            return Users.ChangeUserPassword(this.userID, newPassword);
        }
    }
}
