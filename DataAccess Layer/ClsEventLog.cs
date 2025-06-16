using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class ClsEventLog
    {
        static string sourceName = "DVLDApp";

        public static void AddInformation(string informationMessage)
        {
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            EventLog.WriteEntry(sourceName, informationMessage, EventLogEntryType.Information);
        }

        public static void AddError(string errorMessage)
        {
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            EventLog.WriteEntry(sourceName, errorMessage, EventLogEntryType.Error);
        }
        public static void AddWarning(string warningMessage)
        {
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            EventLog.WriteEntry(sourceName, warningMessage, EventLogEntryType.Warning);
        }
    }
}
