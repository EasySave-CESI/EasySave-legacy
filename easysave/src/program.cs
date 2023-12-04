/* This file will initialize the program application */
using menu;
using System;

namespace easysave
{
    /* Creation of the class ProgramInitialization */
    static class ProgamInitialization
    {
        const string StateFilePath = "../logs/state.json";
        const string DailyLogsPath = "../logs/dailyLogs.json";

        static void Main()
        {
            /* Creation of the object MenuViewModel */
            MenuViewModel menuViewModel = new MenuViewModel(StateFilePath, DailyLogsPath);

            /* Then we call the method ClearView() from the object MenuViewModel */
            menuViewModel.ClearView();

            /* Then we call the method DisplayMenu() from the object MenuViewModel */
            menuViewModel.DisplayMenu();
        }
    }
}