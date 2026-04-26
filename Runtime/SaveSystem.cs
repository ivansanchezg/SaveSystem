using System.IO;
using UnityEngine;

namespace IvanSanchezG.SaveSystem
{
    /// <summary>
    /// Provides a simple, flexible save/load system using JSON or Binary serialization.
    /// Attach this component to a GameObject to enable saving in your project.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use the <c>Save Format</c> field to choose between JSON and Binary.
    /// JSON is human‑readable, resilient to changes, and recommended for most projects.
    /// Binary produces smaller files but is fragile: adding, removing, or reordering fields
    /// in your <c>SaveData</c> classes can break existing save files.
    /// </para>
    /// 
    /// <para>
    /// You can also customize the file extension (default: <c>.save</c>). Files are stored
    /// under <c>Application.persistentDataPath</c>. Refer to Unity’s documentation for
    /// platform‑specific locations.
    /// </para>
    /// </remarks>
    /// <example>
    /// Saving:
    /// <code>
    /// SaveSystem.Instance.Save(mySaveData, "settings");
    /// </code>
    /// 
    /// Loading:
    /// <code>
    /// var data = SaveSystem.Instance.Load&lt;MySaveData&gt;("settings");
    /// </code>
    /// </example>
    public class SaveSystem : MonoBehaviour
    {
        [Header("Save Settings")]
        public SaveFormat saveFormat = SaveFormat.Json;
        public string fileExtension = "save";

        public static SaveSystem instance;

        SaveSerializer serializer;

        void Awake()
        {
            if (instance != null) {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
            serializer = saveFormat switch {
                SaveFormat.Binary => new BinarySaveSerializer(),
                SaveFormat.Json   => new JsonSaveSerializer(),
                _ => new JsonSaveSerializer()
            };
        }

        string GenerateFilePath(string fileName)
        {
            return Path.Combine(Application.persistentDataPath, $"{fileName}.{fileExtension}");
        }

        /// <summary>
        /// Saves the provided <see cref="SaveData"/> instance to disk using the configured serializer.
        /// </summary>
        /// <param name="saveData">The data object to serialize and write to disk.</param>
        /// <param name="fileName">The name of the save file (without extension).</param>
        public void Save(SaveData saveData, string fileName)
        {
            var fullPath = GenerateFilePath(fileName);
            serializer.Serialize(saveData, fullPath);
        }

        /// <summary>
        /// Loads and deserializes a save file of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="SaveData"/> type to load.</typeparam>
        /// <param name="fileName">The name of the save file (without extension).</param>
        /// <returns>The deserialized save data.</returns>
        /// <exception cref="SaveFileNotFoundException">
        /// Thrown when the save file does not exist at the resolved path.
        /// </exception>
        public T Load<T>(string fileName) where T : SaveData
        {
            var fullPath = GenerateFilePath(fileName);
            if (!File.Exists(fullPath)) {
                throw new SaveFileNotFoundException($"Save file not found at path: {fullPath}");
            }
            return serializer.Deserialize<T>(fullPath);
        }

        /// <summary>
        /// Checks whether a save file with the given name exists on disk.
        /// </summary>
        /// <param name="fileName">The name of the save file (without extension).</param>
        /// <returns>True if the file exists; otherwise false.</returns>
        public bool FileExists(string fileName)
        {
            return File.Exists(GenerateFilePath(fileName));
        }

        /// <summary>
        /// Deletes the save file with the given name, if it exists.
        /// </summary>
        /// <param name="fileName">The name of the save file (without extension).</param>
        public void Delete(string fileName)
        {
            var fullPath = GenerateFilePath(fileName);
            if (File.Exists(fullPath)) {
                File.Delete(fullPath);
            }
        }
    }

    public enum SaveFormat {
        Binary,
        Json,
    }
}