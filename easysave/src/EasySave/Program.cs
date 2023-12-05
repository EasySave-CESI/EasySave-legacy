using System;
using System.Collections.Generic;

namespace EasySaveConsoleApp
{
    class Program
    {
        private const string StateFilePath = "C:\\Users\\antoi\\[01]_CESI\\[03]_A3\\[05]_Programmation_Système\\[02]_Projets\\test_v1\\logs\\state.json";

        static void Main(string[] args)
        {
            List<Profile> profiles = Profile.LoadProfiles(StateFilePath);

            if (profiles.Count == 0)
            {
                Console.WriteLine("No backup profiles have been loaded.");
                return;
            }
            else
            {
                Console.WriteLine("Number of loaded profiles: " + profiles.Count);

                var viewModel = new MainViewModel(profiles);
                var consoleView = new ConsoleView(viewModel);

                consoleView.Run();
            }
        }
    }
}
