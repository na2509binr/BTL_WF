using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
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
            Application.Run(new frmMain());
            //Application.Run(new frmBook());
            //Application.Run(new frmCategory());
            //Application.Run(new frmAuthor());
            //Application.Run(new frmPublishingCompany());
            //Application.Run(new frmReader());
            //Application.Run(new frmLibraryCard());
            //Application.Run(new frmBorrow());
            //Application.Run(new frmPay());
        }
    }
}
