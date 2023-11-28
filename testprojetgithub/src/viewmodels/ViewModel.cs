using System;
using System.Collections.Generic;

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

            foreach (var profile in _profiles)
            {
                Console.WriteLine((int.Parse(profile.Name.Substring(profile.Name.Length - 1)) + 1) + ". " + profile.Name + " - " + profile.State + " - " + profile.SourceFilePath + " - " + profile.TargetFilePath);
            }
        }

        public void ModifyProfile()
        {
            Console.WriteLine("\nModifying a backup profile:");

            Console.Write("Enter the profile number to modify (1-5): ");
            int profileNumber;
            if (int.TryParse(Console.ReadLine(), out profileNumber) && profileNumber >= 1 && profileNumber <= 5)
            {
                int index = profileNumber - 1;

                Console.Write("New source path: ");
                string? newSourcePath = Console.ReadLine();
                if (newSourcePath != null)
                {
                    _profiles[index].SourceFilePath = newSourcePath;
                }
                else
                {
                    Console.WriteLine("Invalid source path.");
                }

                Console.Write("New target path: ");
                string? newTargetPath = Console.ReadLine();
                if (newTargetPath != null)
                {
                    _profiles[index].TargetFilePath = newTargetPath;
                }
                else
                {
                    Console.WriteLine("Invalid target path.");
                }

                Console.WriteLine("Backup profile modified successfully.");
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
