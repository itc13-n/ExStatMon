using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Statistics_Monitor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Sectors.InitializeSectors();
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show(ex.Message + "\nContinue?", "Exception catched", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            } // initialize Sectors
            MainForm main = new MainForm();
            main.Show();
            main.FormClosed += new FormClosedEventHandler(FormClosed);
            Application.Run();

        }

        static void FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.loadScreen.Close();
            ((Form)sender).FormClosed -= FormClosed;
            if (Application.OpenForms.Count == 0) Application.ExitThread();
            else Application.OpenForms[0].FormClosed += FormClosed;
            Company.SaveSectors();
        }
    }
}
