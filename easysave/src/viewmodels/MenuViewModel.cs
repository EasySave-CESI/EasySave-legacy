/* MenuViewModel will be the class that will handle the menu view */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace menu
{
    /* Creation of the class MenuViewModel */
    public class MenuViewModel (string StateFilePath, string DailyLogsPath)
    {
        /* Creation of the object MenuView */
        MenuView menuView = new MenuView();

        public void ClearView()
        {
            menuView.ClearView();
        }

        public void DisplayMenu()
        {
            menuView.DisplayMenu();
        }
    }

}