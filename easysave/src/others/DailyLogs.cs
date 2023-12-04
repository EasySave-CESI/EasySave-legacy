namespace dailylog
{
    public class DailyLogs
    {
        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public long FileSize { get; set; }
        public float FileTransferTime { get; set; }
        public string Time { get; set; }

        public void DailyLogsBuilder()
        {
            Name = "";
            SourceFilePath = "";
            TargetFilePath = "";
            FileSize = 0;
            FileTransferTime = 0;
            Time = "";
        }

        public void DailyLogsBuilder(string name, string sourceFilePath, string targetFilePath, long fileSize, float fileTransferTime, string time)
        {
            Name = name;
            SourceFilePath = sourceFilePath;
            TargetFilePath = targetFilePath;
            FileSize = fileSize;
            FileTransferTime = fileTransferTime;
            Time = time;
        }

        public void ReadDailyLogs()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("SourceFilePath: " + SourceFilePath);
            Console.WriteLine("TargetFilePath: " + TargetFilePath);
            Console.WriteLine("FileSize: " + FileSize);
            Console.WriteLine("FileTransferTime: " + FileTransferTime);
            Console.WriteLine("Time: " + Time);
        }

        public void AddDailyLogs(string name, string sourceFilePath, string targetFilePath, long fileSize, float fileTransferTime, string time)
        {
            Name = name;
            SourceFilePath = sourceFilePath;
            TargetFilePath = targetFilePath;
            FileSize = fileSize;
            FileTransferTime = fileTransferTime;
            Time = time;
        }
    }
}