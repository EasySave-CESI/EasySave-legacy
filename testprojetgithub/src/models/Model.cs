using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EasySaveConsoleApp
{
    public class Profile
    {
        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string State { get; set; }
        public int TotalFilesToCopy { get; set; }
        public long TotalFilesSize { get; set; }
        public int NbFilesLeftToDo { get; set; }
        public int Progression { get; set; }

        public Profile(string name, string sourceFilePath, string targetFilePath, string state, int totalFilesToCopy, long totalFilesSize, int nbFilesLeftToDo, int progression)
        {
            Name = name;
            SourceFilePath = sourceFilePath;
            TargetFilePath = targetFilePath;
            State = state;
            TotalFilesToCopy = totalFilesToCopy;
            TotalFilesSize = totalFilesSize;
            NbFilesLeftToDo = nbFilesLeftToDo;
            Progression = progression;
        }

        public override string ToString()
        {
            return $"Name: {Name}, SourceFilePath: {SourceFilePath}, TargetFilePath: {TargetFilePath}, State: {State}";
        }

        public static List<Profile> LoadProfiles(string filePath)
        {
            try
            {
                /* Will read the state.json file and extract all the objects*/
                /* For now it's not implemented yet so we will just create 5 profiles with parameters in a list*/
                List<Profile> profiles = new List<Profile>();

                profiles.Add(new Profile("Save1", "", "", "END", 0, 0, 0, 0));
                profiles.Add(new Profile("Save2", "", "", "END", 0, 0, 0, 0));
                profiles.Add(new Profile("Save3", "", "", "END", 0, 0, 0, 0));
                profiles.Add(new Profile("Save4", "", "", "END", 0, 0, 0, 0));
                profiles.Add(new Profile("Save5", "", "", "END", 0, 0, 0, 0));

                return profiles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading profiles: {ex.Message}");
                return new List<Profile>();
            }
        }

        public static void SaveProfiles(string filePath, List<Profile> profiles)
        {
            try
            {
                string json = JsonConvert.SerializeObject(profiles, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving profiles: {ex.Message}");
            }
        }

        public void Execute()
        {
            Console.WriteLine($"Backing up profile {Name} in progress...");

            try
            {
                string[] files = Directory.GetFiles(SourceFilePath, "*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    string relativePath = file.Replace(SourceFilePath, "");
                    string targetFile = Path.Combine(TargetFilePath, relativePath);

                    string targetDirectory = Path.GetDirectoryName(targetFile);
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    File.Copy(file, targetFile, true);
                    /* Will need to change the daily log with the Name of the save and information about the file that has just been saved*/
                }

                Console.WriteLine($"Backup of profile {Name} completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during backup of profile {Name}: {ex.Message}");
            }
        }
    }
}
