namespace API.Core.Cron
{
    public class CleanTempFolderJob : CronJob
    {
        public override void Process()
        {
            var path = Path.Combine("wwwroot", "temp");
            if (!Directory.Exists(path))
            {
                return;
            }
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                if (DateTime.UtcNow - fileInfo.CreationTime > TimeSpan.FromHours(1))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
