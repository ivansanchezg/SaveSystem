# 📦 Save System (Unity Package)

A modular, extensible, serializer‑agnostic save system for Unity.  
Supports JSON and Binary serialization, custom data types, and pluggable serializers.

---

## 🚀 Installing the Package

You can import this Save System into any Unity project using **one of three methods**.

---
### 1. Install via Git URL (recommended for sharing/updating)

If you host this package in a Git repository:

1. Open **Package Manager**
2. Click **+**
3. Choose **Add package from Git URL…**
4. Enter your repo URL: `https://github.com/ivansanchezg/SaveSystem.git`


Unity will clone the package and keep it versioned.

---
### 2. Install via “Add package from disk…” (local folder)

If you have this package on your machine:

1. Open **Unity → Window → Package Manager**
2. Click the **+** button (top‑left)
3. Select **Add package from disk…**
4. Navigate to the folder: com.ivanchez.savesystem/package.json
5. Select `package.json`

Unity will import the package and compile it automatically.

---

### 3. Install by copying into the project’s Packages folder

You can also drop the package directly into a project:

1. Open your Unity project folder in Explorer/Finder
2. Copy the entire folder: `com.ivanchez.savesystem/`
3. Paste it into: `YourProject/Packages/`

Unity will detect the package automatically.

---

## 🧩 Using the Save System

### 1. Setup the SaveSystem
1. Create an empty GameObject in the hierarchy
2. Click on Add Component and select SaveSystem

### 2. Create your SaveData class

```csharp
public class PlayerSaveData : SaveData
{
    public int level;
    public float health;
    public string playerName;
}
```

### 3. Save

```
string fileName = "myFile"
PlayerSaveData saveData = new PlayerSaveData {
    level = 5,
    health = 72.5f,
    playerName = "John"
};
SaveSystem.instance.Save(saveData, fileName);
```

### 4. Load

```csharp
string fileName = "myFile"
PlayerSaveData data = SaveSystem.instance.Load<PlayerSaveData>(fileName);
```

---

## 📘 Samples

For a more detailed example look at the sample scene and scripts.

To import the sample scene and scripts:

1. Open Package Manager
2. Select Save System
3. Expand Samples
4. Click Import

Unity will copy the sample files into: `Assets/Samples/Save System/<version>/Basic Example/`

---

## 📁 Package Structure

```
com.yourname.savesystem/
│
├── package.json
│
├── Runtime/
│   ├── SaveSystem.cs
│   ├── SaveData.cs
│   └── Serializers/
│
└── Samples/
    └── Basic Example/
        ├── SampleScene.unity
        ├── SampleSaveData.cs
        └── SampleSaveSystemUsage.cs
```


- **Runtime/** → Core save system code (included in builds)  
- **Samples/** → Optional example scene + scripts

---