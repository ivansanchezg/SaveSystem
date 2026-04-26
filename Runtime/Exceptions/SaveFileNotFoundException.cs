using System;

namespace IvanSanchezG.SaveSystem
{
    /// <summary>
    /// Exception thrown when a save file is missing.
    /// </summary>
    public class SaveFileNotFoundException : Exception
    {
        public SaveFileNotFoundException(string path) : base($"Save file not found at path: {path}") { }
    }
}