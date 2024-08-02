using WFtest.Controllers;
using WFtest.Services;

namespace WFtest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DataService dataService = new DataService();
            Form1 mainForm = new Form1();
            MainFormController controller = new MainFormController(mainForm, dataService);
            Application.Run(mainForm);
        }
    }
}