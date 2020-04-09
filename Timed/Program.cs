using System;
using System.Windows.Forms;
using Timed.Forms;

namespace Timed
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Fetch the current user - Code Parked as user identification no longer needed (using local file as a database)
            //string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(out bool success));
            if (!success)
            {
                Application.Exit();
            }
        }
    }
}
