using System;
using System.Collections.Generic;

namespace EasySaveConsoleApp
{
    static class Program
    {
        private const string StateFilePath = ".//.///logs/state.json";

        static void Main(string[] args)
        {
            List<Profile> profiles = Profile.LoadProfiles(StateFilePath);

            if (profiles.Count == 0)
            {
                Console.WriteLine("No backup profiles have been loaded.");
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
