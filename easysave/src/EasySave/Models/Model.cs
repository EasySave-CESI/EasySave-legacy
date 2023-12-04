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
                if (TypeOfSave == "complete")
                {
                    if (Directory.Exists(TargetFilePath))
                    {
                        Directory.Delete(TargetFilePath, true);
                    }

                    Directory.CreateDirectory(TargetFilePath);

                    string[] files = Directory.GetFiles(SourceFilePath, "*", SearchOption.AllDirectories);

                    TotalFilesToCopy = files.Length;

                    foreach (string file in files)
                    {
                        TotalFilesSize += new FileInfo(file).Length;
                    }

                    NbFilesLeftToDo = TotalFilesToCopy;

                    foreach (string file in files)
                    {
                        string relativePath = file.Substring(SourceFilePath.Length + 1);
                        string targetFilePath = Path.Combine(TargetFilePath, relativePath);

                        string targetDirectoryPath = Path.GetDirectoryName(targetFilePath);

                        if (!Directory.Exists(targetDirectoryPath))
                        {
                            Directory.CreateDirectory(targetDirectoryPath);
                        }

                        File.Copy(file, targetFilePath, true);

                        NbFilesLeftToDo--;
                        Progression = (int)(((double)TotalFilesToCopy - NbFilesLeftToDo) / TotalFilesToCopy * 100);
                    }
                }
                else if (TypeOfSave == "differential")
                {
                    Console.WriteLine("Differential backup not implemented yet.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during backup of profile {Name}: {ex.Message}");
            }
        }
    }
}
