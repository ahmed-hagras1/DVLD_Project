using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess_Layer
{
    internal class DataAccessSettings
    {
        
        static public string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
    }
}
