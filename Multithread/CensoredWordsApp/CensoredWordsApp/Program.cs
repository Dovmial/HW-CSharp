using System;
using System.Threading;
using System.Windows.Forms;

namespace CensoredWordsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool oneOnly;
            Mutex mtex = new Mutex(true, "CensoredWordsAppUnique", out oneOnly);
            if (oneOnly)
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
                MessageBox.Show("Alreade exist!");
        }
    }
}
