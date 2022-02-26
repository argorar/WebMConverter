using System;
using System.Net;

using Semver;

namespace WebMConverter.Updater
{
    static partial class Program
    {
        public static bool CheckUpdate(string currentVerString, out string output)
        {
            output = "";

            try
            {
                var currentVersion = SemVersion.Parse(currentVerString);
                SemVersion latestVersion;

                using (var updateChecker = new WebClient())
                {
                    var result = updateChecker.DownloadString(VersionUrl);
                    
                    latestVersion = SemVersion.Parse(result);
                    output += $"The last version is {latestVersion}";
                }

                if (latestVersion > currentVersion)
                {

                    output = latestVersion.ToString();
                    output += Environment.NewLine;

                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                output = e.Message;
                return false;
            }
        }
    }
}