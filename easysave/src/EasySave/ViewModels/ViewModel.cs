﻿using System;
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
                int index = profileNumber - 1;

                Console.Write("New source path: ");
                string newSourcePath = Console.ReadLine();
                _profiles[index].SourceFilePath = newSourcePath;

                Console.Write("New target path: ");
                string newTargetPath = Console.ReadLine();
                _profiles[index].TargetFilePath = newTargetPath;

                Console.Write("New type of save (complete or differential): ");
                string newTypeOfSave = Console.ReadLine();
                _profiles[index].TypeOfSave = newTypeOfSave;

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
