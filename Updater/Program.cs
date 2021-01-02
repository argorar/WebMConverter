using System;
using System.Net;
using System.Windows.Forms;

namespace WebMConverter.Updater
{
    static partial class Program
    {
        public const string VersionUrl = @"https://argorar.github.io/WebMConverter/NewUpdate/latest";
        public const string ProgramUrl = @"https://argorar.github.io/WebMConverter/NewUpdate/{0}.zip";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (args.Length == 0)
            {
                MessageBox.Show("No mode specified. You shouldn't be running this directly!");
                return 1;
            }

            var mode = args[0];
            if (mode.Equals("check"))
            {
               var current = args[1];
               string output;
               var success = CheckUpdate(current, out output);
               return success ? 0 : 1;
            }
            else if (mode.Equals("update"))
            {
                Application.Run(new UpdateUI());
                return 0;
            } 
            return 1;
        }
    }
}
