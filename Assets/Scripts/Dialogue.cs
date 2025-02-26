using UnityEngine;
using System.IO;

public class Dialogue : MonoBehaviour
{
    public JsonData jsonData;
    [ContextMenu("To Json Data")]
    void SaveDataToJson()
    {
        string jD = JsonUtility.ToJson(jsonData,true);
        string path = Path.Combine(Application.streamingAssetsPath, "dgData.json");
        File.WriteAllText(path, jD);
    }

    [ContextMenu("From Json Data")]
    void LoadDataFromJson()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "dgData.json");
        string jD = File.ReadAllText(path);
        jsonData = JsonUtility.FromJson<JsonData>(jD);
    }
}

[System.Serializable]
public class JsonData
{
    public SceneData[] scenes;
}

[System.Serializable]
public class SceneData
{
    public string sceneID;
    public BG background;
    public DialogueData[] dialogueDatas;
    public SceneData()
    {
        sceneID = "Game";
    }
}

[System.Serializable]
public class DialogueData
{
    public string dialogueID;
    public Character character;
    public string text;
    public EMOTION emotion;
    public NPC position;
    public int textSpeed;
    public int fontSize;
    public string fontType;
    public DialogueData()
    {
        emotion = EMOTION.basic;
        textSpeed = 50;
        fontSize = 40;
        fontType = "Preesentation";
        position = NPC.Middle;
    }
}
