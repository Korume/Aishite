using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Aishite.SettignsManagement
{
    public class JsonSettingsProvider : ISettingsProvider
    {
        private readonly string _settingsPath = "settings.json";//ConfigurationManager.AppSettings["SettingsPath"];

        public Settings Get()
        {
            bool isFileExist = File.Exists(_settingsPath);
            var settings = isFileExist ? LoadFromFile() ?? CreateDefaultSettingsFile() : CreateDefaultSettingsFile();
            return settings;
        }

        private Settings CreateDefaultSettingsFile() => Save(Settings.CreateDefault());

        private Settings? LoadFromFile()
        {
            using var fileStream = new FileStream(_settingsPath, FileMode.Open);
            
            var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
            
            try
            {
                return (Settings?)jsonFormatter.ReadObject(fileStream);
            }
            catch (SerializationException)
            {
                return null;
            }
        }

        public Settings Save(Settings settingsForSave)
        {
            using (var fileInfo = new FileStream(_settingsPath, FileMode.Create))
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
                jsonFormatter.WriteObject(fileInfo, settingsForSave);
            }
            return settingsForSave;
        }
    }
}
