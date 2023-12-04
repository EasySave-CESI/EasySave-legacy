using System;
using System.Collections.Generic;
using System.IO;

namespace EasySaveConsoleApp
{
    public class MainViewModel
    {
        private readonly List<Profile> _profiles;

        public MainViewModel(List<Profile> profiles)
        {
            _profiles = profiles;
        }

        public void DisplayProfiles()
        {
            Console.WriteLine("\nList of backup profiles:");

            Console.WriteLine("Name - State - Source path - Target path");

            foreach (var profile in _profiles)
            {
                Console.WriteLine((int.Parse(profile.Name.Substring(profile.Name.Length - 1)) + 1) + ". " + profile.Name + " - " + profile.State + " - " + profile.SourceFilePath + " - " + profile.TargetFilePath + " - " + profile.TypeOfSave);
            }
        }

        public void ModifyProfile()
        {
            Console.WriteLine("\nModifying a backup profile:");

            Console.Write("Enter the profile number to modify (1-5): ");
            int profileNumber;
            if (int.TryParse(Console.ReadLine(), out profileNumber) && profileNumber >= 1 && profileNumber <= 5)
            {
                int index = profileNumber -1;

                Console.Write("New source path: ");

                _profiles[index].SourceFilePath = Console.ReadLine();
                Console.WriteLine("New source path: " + _profiles[index].SourceFilePath);
     

                Console.Write("New target path: ");
                _profiles[index].TargetFilePath = Console.ReadLine();
                Console.WriteLine("New target path: " + _profiles[index].TargetFilePath);

                Console.Write("New type of save (full of diff): ");
                if (Console.ReadLine() == "full")
                {
                    _profiles[index].TypeOfSave = "full";
                }
                else
                {
                    _profiles[index].TypeOfSave = "diff";
                }

                string[] files = Directory.GetFiles(_profiles[index].SourceFilePath, "*", SearchOption.AllDirectories);

                _profiles[index].TotalFilesToCopy = files.Length;

                foreach (string file in files)
                {
                    /* Add the size of the file to the total size of the profile in long */
                    _profiles[index].TotalFilesSize += new FileInfo(file).Length;
                    Console.WriteLine("Total size of the profile: " + _profiles[index].TotalFilesSize);
                }

                _profiles[index].State = "READY";
                /* Then save the profiles to the state file */
                Profile.SaveProfiles("C:\\Users\\antoi\\[01]_CESI\\[03]_A3\\[05]_Programmation_Système\\[02]_Projets\\test_v1\\logs\\state.json", _profiles);
            }
            else
            {
                Console.WriteLine("Invalid profile number. Please enter a number between 1 and 5.");
            }
        }

        public void ExecuteProfile()
        {
            Console.WriteLine("\nExecuting a backup:");

            Console.Write("Enter the profile number to execute (1-5): ");
            int profileNumber;
            if (int.TryParse(Console.ReadLine(), out profileNumber) && profileNumber >= 1 && profileNumber <= 5)
            {
                int index = profileNumber - 1;

                _profiles[index].Execute();
            }
            else
            {
                Console.WriteLine("Invalid profile number. Please enter a number between 1 and 5.");
            }
        }
    }
}
