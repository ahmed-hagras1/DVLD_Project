using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class TestType
    {
        public enum en_TestType { VisionTest =1 , WrittenTest = 2 , PracticalTest =3 }
        enum en_Mode { UpdateMode = 0 , AddNewMode = 1};
        en_Mode Mode = en_Mode.AddNewMode;

        public en_TestType testTypeID { get; set; }
        public string testTypeTitle { get; set; }
        public string testTypeDescription { get; set; }
        public float testTypeFees { get; set; }

        public TestType()
        {
            testTypeID = 0;
            testTypeTitle = "";
            testTypeDescription = "";
            testTypeFees = 0;

            Mode = en_Mode.AddNewMode;
        }

        private TestType(en_TestType testTypeID , string testTypeTitle , string testTypeDescription , float testTypeFees)
        {
            this.testTypeID = testTypeID;
            this.testTypeTitle = testTypeTitle;
            this.testTypeDescription = testTypeDescription;
            this.testTypeFees = testTypeFees;

            Mode = en_Mode.UpdateMode;
        }

        public static DataTable GetAllTestTypes() => TestTypes.GetAllTestTypes();

        public static TestType FindTestTypeByID(en_TestType testTypeID)
        {
            string testTypeTitle = "", testTypeDescription = "";
            float testTypeFees = 0;

            return (TestTypes.FindTestTypeByID((int)testTypeID, ref testTypeTitle, ref testTypeDescription, ref testTypeFees)) ?
                new TestType(testTypeID, testTypeTitle, testTypeDescription, testTypeFees) : null;
        }

        private bool _UpdateTestType() => TestTypes.UpdateTestType((int)testTypeID, testTypeTitle, testTypeDescription, testTypeFees);

        private bool _AddNewTestType() => (TestTypes.AddNewTestType(testTypeTitle, testTypeDescription, testTypeFees) != -1);
        public bool Save()
        {
            switch (Mode)
            {
                case en_Mode.UpdateMode:
                    return _UpdateTestType();
                    break;
                case en_Mode.AddNewMode:
                    if (_AddNewTestType())
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

        public static bool IsTestTypeExist(int testTypeID) => TestTypes.IsTestTypeExist(testTypeID); 
    }
}
