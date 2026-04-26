using Newtonsoft.Json;
using System.IO;

namespace IvanSanchezG.SaveSystem {
    public class JsonSaveSerializer : SaveSerializer
    {
        public void Serialize(SaveData data, string fullPath)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(fullPath, json);
        }

        public T Deserialize<T>(string fullPath) where T : SaveData
        {
            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}