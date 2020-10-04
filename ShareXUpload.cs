using Microsoft.Win32;
using System.Diagnostics;

namespace WebMConverter
{
    static class ShareXUpload
    {
        public static bool Enabled { get; private set; }
        public static string InstallPath { get; private set; }

        public static void CheckEnabled()
        {
            var installPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\*\shell\ShareX\command", null, null);
            if (installPath == null) return;
            Enabled = true;

            var start = installPath.IndexOf('"') + 1;
            var end = installPath.IndexOf('"', start);
            InstallPath = installPath.Substring(start, end - start);
        }
    }

    class ShareX : Process
    {
        public ShareX(string filename)
        {
            if (!ShareXUpload.Enabled) return;

            StartInfo.FileName = ShareXUpload.InstallPath;
            StartInfo.Arguments = $@"""{filename}""";
        }
    }
}
