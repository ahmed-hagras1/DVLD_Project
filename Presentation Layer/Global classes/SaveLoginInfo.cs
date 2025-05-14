
using Business_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public class SaveLoginInfo
    {
        public static User currentUser;
        public static bool RememberLoginInfo(string username , string password)
        {
            try
            {
                // current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // The path to the text file.
                string filePath = currentDirectory + "\\LoginInfo.txt";

                // Incase the username is empty, delete the file.
                if (username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                // save user name and password with separator.
                string dataToSave = username + "#//#" + password;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(dataToSave);
                    return true;
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
           
        }
        public static bool GetStoredLoginInfo(ref string username ,ref string password)
        {
            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = currentDirectory + "\\LoginInfo.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null )
                        {
                            string[] result;

                            result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            username = result[0];
                            password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
           
        }

    }
}
