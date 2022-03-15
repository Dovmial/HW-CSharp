using System.Diagnostics;
namespace RouletteCasino
{
    internal static class Program
    {
        static int createdNew = 0;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //не более 3 процессов с таким именем
            int count = Process.GetProcessesByName(Application.ProductName).Length;
            if (count < 4)
            {

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                createdNew++;
                ApplicationConfiguration.Initialize();
                Random _random = new Random();
                Application.Run(new Form1(_random));

            }

            else
            {
                MessageBox.Show($"ѕревышен лимит одновременно запускаемых окон приложени€");
            }
        }

    }
}
