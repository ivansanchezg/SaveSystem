using IvanSanchezG.SaveSystem;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class SampleSaveSystemUsage : MonoBehaviour
{
    private SampleSaveData sampleSaveData;

    private string fileName = "saveData";

    void Start()
    {
        var character = new Character(
            "John",
            "Doe",
            30,
            new Dictionary<string, int>() {
                { "hp", 20 },
                { "atk", 10 },
                { "def", 8 },
            }
        );

        // Modify the values of this instance
        sampleSaveData = new SampleSaveData(
            10,
            3583.31f,
            ClassType.Warrior,
            new List<string>() { "For glory!", "Attack!!!", "Charge!" },
            new Dictionary<string, int>() {
                { "sword", 2 },
                { "shield", 1 },
                { "potion", 10 },
            },
            character
        );
    }

    public void Save()
    {
        print("Saving file");
        SaveSystem.instance.Save(sampleSaveData, fileName);
        print("File saved successfully");
    }

    public void Load()
    {
        print("Loading file");
        var loadedSaveData = SaveSystem.instance.Load<SampleSaveData>(fileName);
        print("File loaded successfully");

        // Converting SaveData to string to print it in the console
        var loadedSaveDataStr = JsonConvert.SerializeObject(loadedSaveData, Formatting.Indented);
        print($"Loaded SaveData: {loadedSaveDataStr}");
    }
}
