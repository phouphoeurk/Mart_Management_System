
using DotNetEnv;
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
            Env.Load();//Load data from env to use connection string
            ApplicationConfiguration.Initialize();
            Application.Run(new Forms.LoginForm());
            
        }
    }
}