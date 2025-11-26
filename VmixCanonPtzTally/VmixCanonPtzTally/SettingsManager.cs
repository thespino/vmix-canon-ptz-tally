using System.Xml.Serialization;

namespace VmixCanonPtzTally
{
    public static class SettingsManager
    {
        private const string RecentFilesKey = "RecentFiles";
        private const string LastFileKey = "LastFile";
        private const int MaxRecentFiles = 10;

        public static AppSettings LoadFromFile(string filePath)
        {
            try
            {
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var serializer = new XmlSerializer(typeof(AppSettings));
                var settings = (AppSettings?)serializer.Deserialize(stream);
                return settings ?? new AppSettings();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load settings: {ex.Message}", ex);
            }
        }

        public static void SaveToFile(string filePath, AppSettings settings)
        {
            try
            {
                using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                var serializer = new XmlSerializer(typeof(AppSettings));
                serializer.Serialize(stream, settings);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save settings: {ex.Message}", ex);
            }
        }

        public static List<string> GetRecentFiles()
        {
            try
            {
                var recentFilesString = Properties.Settings.Default.RecentFiles;
                if (string.IsNullOrEmpty(recentFilesString))
                    return new List<string>();

                return recentFilesString
                    .Split('|')
                    .Where(f => !string.IsNullOrWhiteSpace(f) && File.Exists(f))
                    .Take(MaxRecentFiles)
                    .ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        public static void AddRecentFile(string filePath)
        {
            try
            {
                var recentFiles = GetRecentFiles();

                // Remove if already exists
                recentFiles.Remove(filePath);

                // Add to beginning
                recentFiles.Insert(0, filePath);

                // Keep only max items
                if (recentFiles.Count > MaxRecentFiles)
                    recentFiles = recentFiles.Take(MaxRecentFiles).ToList();

                // Save
                Properties.Settings.Default.RecentFiles = string.Join("|", recentFiles);
                Properties.Settings.Default.Save();
            }
            catch
            {
                // Ignore errors in recent files tracking
            }
        }

        public static string? GetLastFile()
        {
            try
            {
                var lastFile = Properties.Settings.Default.LastFile;
                if (!string.IsNullOrEmpty(lastFile) && File.Exists(lastFile))
                    return lastFile;
            }
            catch
            {
                // Ignore
            }
            return null;
        }

        public static void SetLastFile(string? filePath)
        {
            try
            {
                Properties.Settings.Default.LastFile = filePath ?? "";
                Properties.Settings.Default.Save();
            }
            catch
            {
                // Ignore
            }
        }
    }
}
