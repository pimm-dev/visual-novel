using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

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
    public string bgm;
    public string background;
    public DialogueData[] dialogueDatas;
}

[System.Serializable]
    public class DialogueData
    {
        public string dialogueID;
        public string character;
        public string text;
        public string emotion;
        public string position;
        public string[] effects;
        public bool shakeEffect;
        public int textSpeed;
        public string[] sfx;
        public float duration;
        public int fontSize;
        public string fontType;
        public DialogueData()
        {
            emotion = "happy";
            shakeEffect = false;
            duration = 2.5f;
            textSpeed = 50;
            fontSize = 48;
            fontType = "Preesentation";
            position = "middle";
            effects = new string[] {"fadeIn", "e1", "e2"};
            sfx = new string[] {"door_creak.mp3", "s1", "s2"};
        }
    }
