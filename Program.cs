
using Mart_Management_System.Forms;

namespace Mart_Management_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // ប្រើ Testconnection ដើម្បីសាកល្បង Database
            //Application.Run(new Testconnection());
            
            Application.Run(new Forms.LoginForm());
            // ប្រើ Testconnection ដើម្បីសាកល្បង Database
            Application.Run(new Testconnection());
        }
    }
}