using IvanSanchezG.SaveSystem;
using System.Collections.Generic;

/*
 * This is a sample class to represent how to create a class for storing data
 * that will be stored in your save files.
 * 
 * All classes that are used for save files need to extend SaveData.
 * If you are using binary save files the classes must include the [System.Serializable] attribute.
 */
[System.Serializable]
public class SampleSaveData : SaveData
{
    public int level;
    public float exp;
    public ClassType classType;
    public List<string> dialogs;
    public Dictionary<string, int> items;
    public Character character;

    public SampleSaveData(
        int level,
        float exp,
        ClassType classType,
        List<string> dialogs,
        Dictionary<string, int> items,
        Character character
    )
    {
        this.level = level;
        this.exp = exp;
        this.classType = classType;
        this.dialogs = dialogs;
        this.items = items;
        this.character = character;
    }
}

[System.Serializable]
public class Character
{
    public string firstName;
    public string lastName;
    public int age;
    public Dictionary<string, int> stats;

    public Character(
        string firstName,
        string lastName,
        int age,
        Dictionary<string, int> stats
    )
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.stats = stats;
    }
}

public enum ClassType
{
    Warrior,
    Mage,
    Thief,
}