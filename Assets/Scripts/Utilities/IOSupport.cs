using System.IO;
using UnityEngine;

public class IOSupport
{
    public static SerializableDialogueFlow LoadDialogueData(string target)
    {
        string path = Path.Combine(Application.streamingAssetsPath, target);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Dialogue ${target}'s data file(${path}) not found.");
        }
        string raw = File.ReadAllText(path);
        SerializableDialogueFlow data = JsonUtility.FromJson<SerializableDialogueFlow>(raw);
        return data;
    }
}
