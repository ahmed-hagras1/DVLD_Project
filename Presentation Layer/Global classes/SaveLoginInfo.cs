
using Business_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Presentation_Layer
{
    
    public class SaveLoginInfo
    {
        public static User currentUser;

        public static string keyPath  = @"HKEY_CURRENT_USER\Software\LoginInfo";
        public static string valueName = "LoginInfo";
        public static string valueData;
        public static bool RememberLoginInfo(string username , string password)
        {
            try
            {
                 valueData = username + "#//#" + password;

                // Incase the username is empty, delete the file.
                // Note --> Do not include the root (HKEY_CURRENT_USER) when calling function in CurrentUser — that's already specified by Registry.CurrentUser.
                if (username == "" && Registry.CurrentUser.OpenSubKey(@"Software\LoginInfo") != null)
                {
                    try
                    {
                        // Open the registry key in read/write mode with explicit registry view
                        using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                        {
                            using (RegistryKey key = baseKey.OpenSubKey(@"Software\LoginInfo", true))
                            {
                                if (key != null)
                                {
                                    // Delete the specified value
                                    key.DeleteValue(valueName);
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Registry key not found. Unable to delete login info.");
                                }
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("You do not have permission to delete the login info. Please run the application as an administrator.");
                        return false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting login info: {ex.Message}");
                        return false;
                    }
                }

                try
                {
                    Registry.SetValue(keyPath, valueName, valueData);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving login info: {ex.Message}");
                    return false;
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
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\LoginInfo"))
                {
                    if (key != null)
                    {
                        try
                        {
                            valueData = Registry.GetValue(keyPath, valueName, null) as string;

                            if (valueData != null)
                            {
                                string[] result = valueData.Split(new string[] { "#//#" }, StringSplitOptions.None);
                                username = result[0];
                                password = result[1];
                                return true;
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
                    else
                    {
                        return false;
                    }
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
