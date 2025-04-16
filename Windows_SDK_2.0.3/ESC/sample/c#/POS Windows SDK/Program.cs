using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormUSB
{
    static class Program
    {
        /// <summary>
        /// Mzin entry of application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
