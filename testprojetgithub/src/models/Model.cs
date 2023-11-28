using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EasySaveConsoleApp
{
    public class Profile
    {
        public string Name { get; set; } = string.Empty;
        public string SourceFilePath { get; set; } = string.Empty;
        public string TargetFilePath { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int TotalFilesToCopy { get; set; }
        public long TotalFilesSize { get; set; }
        public int NbFilesLeftToDo { get; set; }
        public int Progression { get; set; }

        private Profile() { }

        public static ProfileBuilder Builder() => new ProfileBuilder();

        public class ProfileBuilder
        {
            public Profile _profile;

            public ProfileBuilder()
            {
                _profile = new Profile();
            }

            public ProfileBuilder WithName(string name)
            {
                _profile.Name = name;
                return this;
            }

            public ProfileBuilder WithSourceFilePath(string sourceFilePath)
            {
                _profile.SourceFilePath = sourceFilePath;
                return this;
            }

            public ProfileBuilder WithTargetFilePath(string targetFilePath)
            {
                _profile.TargetFilePath = targetFilePath;
                return this;
            }

            public ProfileBuilder WithState(string state)
            {
                _profile.State = state;
                return this;
            }

            public ProfileBuilder WithTotalFilesToCopy(int totalFilesToCopy)
            {
                _profile.TotalFilesToCopy = totalFilesToCopy;
                return this;
            }

            public ProfileBuilder WithTotalFilesSize(long totalFilesSize)
            {
                _profile.TotalFilesSize = totalFilesSize;
                return this;
            }

            public ProfileBuilder WithNbFilesLeftToDo(int nbFilesLeftToDo)
            {
                _profile.NbFilesLeftToDo = nbFilesLeftToDo;
                return this;
            }

            public ProfileBuilder WithProgression(int progression)
            {
                _profile.Progression = progression;
                return this;
            }

            public Profile Build() => _profile;
        }

        public static List<Profile> LoadProfiles(string filePath)
        {
            try
            {
                List<Profile> profiles = new List<Profile>();

                profiles.Add(Profile.Builder().WithName("Save1").WithState("END").Build());
                profiles.Add(Profile.Builder().WithName("Save2").WithState("END").Build());
                profiles.Add(Profile.Builder().WithName("Save3").WithState("END").Build());
                profiles.Add(Profile.Builder().WithName("Save4").WithState("END").Build());
                profiles.Add(Profile.Builder().WithName("Save5").WithState("END").Build());

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

                    if (Path.GetDirectoryName(targetFile) == null)
                    {
                        throw new ArgumentNullException(nameof(targetFile));
                    }
                    string targetDirectory = Path.GetDirectoryName(targetFile) ?? "defaultValue";
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    File.Copy(file, targetFile, true);
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
