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
        public string TypeOfSave { get; set; }

        public Profile(string name, string sourceFilePath, string targetFilePath, string state, int totalFilesToCopy, long totalFilesSize, int nbFilesLeftToDo, int progression, string typeOfSave)
        {
            Name = name;
            SourceFilePath = sourceFilePath;
            TargetFilePath = targetFilePath;
            State = state;
            TotalFilesToCopy = totalFilesToCopy;
            TotalFilesSize = totalFilesSize;
            NbFilesLeftToDo = nbFilesLeftToDo;
            Progression = progression;
            TypeOfSave = typeOfSave;
        }

        public override string ToString()
        {
            return $"Name: {Name}, SourceFilePath: {SourceFilePath}, TargetFilePath: {TargetFilePath}, State: {State}";
        }

        public static List<Profile> LoadProfiles(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                List<Profile> profiles = JsonConvert.DeserializeObject<List<Profile>>(json);
                foreach (Profile profile in profiles)
                {
                    Console.WriteLine(profile.Name);
                }

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
