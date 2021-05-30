using System;
using System.Threading;
using System.Windows.Forms;

namespace SpotifySongAvailabilityChecker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "Spotify Song Availability Checker";
            _ = new Mutex(true, appName, out bool appNotLoaded);

            if (!appNotLoaded)
            {
                MessageBox.Show("You cannot have more than one instance of this program running", $"{appName} is already running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Startup());
        }
    }
}
