using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();


        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + "; " +
                LoginValidation.currentUserUsername + "; " +
                LoginValidation.currentUserRole + "; " +
                activity;
            currentSessionActivities.Add(activityLine);
            File.AppendAllText("../../test.txt", activityLine + Environment.NewLine);
        }

        static public string AllLogs()
        {
            string[] allLines = File.ReadAllLines("../../test.txt");
            StringBuilder sb = new StringBuilder();
            foreach (string line in allLines)
            {
                sb.Append(line + "\n");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        static public string GetCurrentSessionLogs(string filter)
        {
            StringBuilder sb = new StringBuilder();
            List<string> filteredLogs = (from line in currentSessionActivities where line.Contains(filter) select line).ToList();
            foreach (string line in filteredLogs)
            {
                sb.Append(line + "\n");
            }
            sb.Remove(sb.Length -1, 1);
            return sb.ToString();
        }
    }
}
