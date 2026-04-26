namespace IvanSanchezG.SaveSystem {
    public interface SaveSerializer
    {
        void Serialize(SaveData data, string fullPath);
        T Deserialize<T>(string fullPath) where T : SaveData;
    }
}