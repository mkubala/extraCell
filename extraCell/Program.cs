using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace extraCell
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            extraCell.view.MDIUI main = new extraCell.view.MDIUI();
            extraCell.helpers.Helpers.mainWindow = main;
            Application.Run(main);
        }
    }
}
