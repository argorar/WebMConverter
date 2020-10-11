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
                    output += $"Good news, out there is a new version {latestVersion}";
                }

                if (latestVersion > currentVersion)
                {
                    // New update available -- pull down the changelog
                    //var changelogUrlFormatted = string.Format(ChangelogUrl, latestVersion.ToString());

                    output = latestVersion.ToString();
                    output += Environment.NewLine;

                    //using (var changelogDownloader = new WebClient())
                    //{
                    //    output += changelogDownloader.DownloadString(changelogUrlFormatted);
                    //}
                    return true; // All went well
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