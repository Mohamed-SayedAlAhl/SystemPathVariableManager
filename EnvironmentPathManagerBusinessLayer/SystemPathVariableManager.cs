using System;
using System.Linq;
using System.Security.Principal;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace SystemPathVariableManagerBusinessLayer
{
    public class SystemPathVariableManager
    {
        private const string PathVariableName = "PATH";
        private string CurrentPath { get; set; }

        public SystemPathVariableManager()
        {
           
            this.CurrentPath = Environment.GetEnvironmentVariable(PathVariableName, EnvironmentVariableTarget.Machine);
        }

      

        public void SavingPath(string GivenPath)
        {
            Environment.SetEnvironmentVariable(PathVariableName, GivenPath, EnvironmentVariableTarget.Machine);
        }

       
        public string GetCurrentPath()
        {
            return CurrentPath;
        }

      
        public bool BackupPath(string backupFilePath)
        {
            try
            {
                // Get the current PATH environment variable for the machine
                string pathVariable = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);

                // Check if the pathVariable is not null or empty
                if (!string.IsNullOrEmpty(pathVariable))
                {
                    // Write the PATH variable to the specified file
                    File.WriteAllText(backupFilePath, pathVariable);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception )
            {
                return false;
            }
        }

        


    }

}
