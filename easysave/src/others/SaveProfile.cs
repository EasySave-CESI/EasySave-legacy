namespace save
{
    public class SaveProfile
    {
        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string State { get; set; }
        public int TotalFilesToCopy { get; set; }
        public long TotalFilesSize { get; set; }
        public int NbFilesLeftToCopy { get; set; }
        public float Progression { get; set; }
        public string TypeOfSave { get; set; }

        public void SaveProfileBuilder()
        {
            Name = "";
            SourceFilePath = "";
            TargetFilePath = "";
            State = "";
            TotalFilesToCopy = 0;
            TotalFilesSize = 0;
            NbFilesLeftToCopy = 0;
            Progression = 0;
            TypeOfSave = "";
        }

        public void SaveProfileBuilder(string name, string sourceFilePath, string targetFilePath, string state, int totalFilesToCopy, long totalFilesSize, int nbFilesLeftToCopy, float progression, string typeOfSave)
        {
            Name = name;
            SourceFilePath = sourceFilePath;
            TargetFilePath = targetFilePath;
            State = state;
            TotalFilesToCopy = totalFilesToCopy;
            TotalFilesSize = totalFilesSize;
            NbFilesLeftToCopy = nbFilesLeftToCopy;
            Progression = progression;
            TypeOfSave = typeOfSave;
        }

        public void EditSaveProfile(string name, string sourceFilePath, string targetFilePath, string state, int totalFilesToCopy, long totalFilesSize, int nbFilesLeftToCopy, float progression, string typeOfSave)
        {
            Name = name;
            SourceFilePath = sourceFilePath;
            TargetFilePath = targetFilePath;
            State = state;
            TotalFilesToCopy = totalFilesToCopy;
            TotalFilesSize = totalFilesSize;
            NbFilesLeftToCopy = nbFilesLeftToCopy;
            Progression = progression;
            TypeOfSave = typeOfSave;
        }

        public void DisplaySaveProfile()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("SourceFilePath: " + SourceFilePath);
            Console.WriteLine("TargetFilePath: " + TargetFilePath);
            Console.WriteLine("State: " + State);
            Console.WriteLine("TotalFilesToCopy: " + TotalFilesToCopy);
            Console.WriteLine("TotalFilesSize: " + TotalFilesSize);
            Console.WriteLine("NbFilesLeftToCopy: " + NbFilesLeftToCopy);
            Console.WriteLine("Progression: " + Progression);
            Console.WriteLine("TypeOfSave: " + TypeOfSave);
        }

        public void ExecuteFullSave()
        {
            Console.WriteLine("ExecuteFullSave");
        }

        public void ExecuteDifferentialSave()
        {
            Console.WriteLine("ExecuteDifferentialSave");
        }
    }
}