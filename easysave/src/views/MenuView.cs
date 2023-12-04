<<<<<<< HEAD
/* This file will display the menu view on a console */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace menu
{
    /* Creation of the class MenuView */
    public class MenuView
    {
        public void ClearView()
        {
            Console.Clear();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to EasySave");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Create a new backup");
            Console.WriteLine("2. Restore a backup");
            Console.WriteLine("3. Display logs");
            Console.WriteLine("4. Exit");
        }

        public void DisplayBackupType()
        {
            Console.WriteLine("Please select a backup type:");
            Console.WriteLine("1. Full");
            Console.WriteLine("2. Differential");
        }

    }

=======
using System;
using System.Collections.Generic;
using System.Text;
using EasySaveApp.controller;
using EasySaveApp.model;

namespace easysave
{
    class MenuView
    {
        public void DisplayMenu()
        { 

        }
    }
>>>>>>> a43b4b15f46d9c11dcd7bc19fd925d6a6582e6f9
}