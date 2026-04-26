using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IvanSanchezG.SaveSystem {
    public class BinarySaveSerializer : SaveSerializer
    {
        public void Serialize(SaveData data, string fullPath)
        {
            using var fileStream = new FileStream(fullPath, FileMode.Create);
            var formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, data);
        }

        public T Deserialize<T>(string fullPath) where T : SaveData
        {
            using var fileStream = new FileStream(fullPath, FileMode.Open);
            var formatter = new BinaryFormatter();
            return (T) formatter.Deserialize(fileStream);
        }
    }
}