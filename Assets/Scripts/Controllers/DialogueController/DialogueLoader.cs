using System;
using System.IO;
using UnityEngine;

public class DialogueLoader
{
    public static object LoadDialogueFlow(string target, string version = "2")
    /**
     * There has been changed the format of the dialogue data.
     * Type casting is required for the return value.
     * v1: Deprecated
     * v2: SerializableDialogueFlow
     */
    {
        switch (version)
        {
            case "1":
                return LoadDialogueFlow1(target);
                break;
            case "2":
                return LoadDialogueFlow2(target);
                break;
            default:
                throw new ArgumentException($"Invalid version: {version}");
        }
    }
    public static object LoadDialogueFlow1(string target)
    {
        throw new DeprecatedApiException();
    }

    public static SerializableDialogueFlow LoadDialogueFlow2(string target)
    {
        string filename = $"{target}.v2.flow.json";
        string path = Path.Combine(Application.streamingAssetsPath, "StoryDialogueFlows", filename);
        if (!File.Exists(path))
        {
            filename = $"chapter{target}.v2.flow.json";
            path = Path.Combine(Application.streamingAssetsPath, "StoryDialogueFlows", filename);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Dialogue {target}'s data file({path}) not found.");
            }
        }
        string raw = File.ReadAllText(path);
        SerializableDialogueFlow data = JsonUtility.FromJson<SerializableDialogueFlow>(raw);
        return data;
    }
}
