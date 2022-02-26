using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WebMConverter.Updater
{
    static partial class Program
    {
        public const string VersionUrl = @"https://argorar.github.io/WebMConverter/NewUpdate/latest";
        public const string ProgramUrl = @"https://argorar.github.io/WebMConverter/NewUpdate/{0}.zip";

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(h, 0);
            Application.EnableVisualStyles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (args.Length == 0)
            {
                MessageBox.Show("No mode specified. You shouldn't be running this directly!");
                return 1;
            }

            var mode = args[0];
            switch (mode)
            {
                case "check":
                    var current = args[1];
                    string output;

                    var success = CheckUpdate(current, out output);
                    Console.Write(output);

                    return success ? 0 : 1;

                case "update":
                    Application.Run(new UpdateUI());
                    return 0;
            }

            Console.WriteLine("Invalid mode");
            return 1;
        }
    }
}
