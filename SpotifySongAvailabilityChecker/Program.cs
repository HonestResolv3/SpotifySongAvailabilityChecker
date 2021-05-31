using System;
using System.Threading;
using System.Windows.Forms;

namespace SpotifySongAvailabilityChecker
{
    static class Program
    {
        static Mutex mu;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            const string appName = "Spotify Song Availability Checker";
            mu = new Mutex(true, appName, out bool appNotLoaded);

            if (!appNotLoaded)
            {
                MessageBox.Show("You cannot have more than one instance of this program running", $"{appName} is already running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Startup());
        }
    }
}
