using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Chat : MonoBehaviour
{
    public Image emptyImage;
    public Sprite changeSprite;

    public TMPro.TMP_Text ChatText;
    public TMPro.TMP_Text CharacterName;

    public string writerText = "";

    private JsonData dialogueRoot;

    // Start is called before the first frame update
    void Start()
    {
        LoadDialogueData("dgData.json");
        StartCoroutine(PlayDialogues());
    }

    void LoadDialogueData(string fileName)
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(path))
        {
            string jsonText = File.ReadAllText(path);
            dialogueRoot = JsonUtility.FromJson<JsonData>(jsonText);
            Debug.Log("Dialogue data loaded successfully.");
        }
        else
        {
            Debug.LogError($"File not found at path: {path}");
        }
    }

    IEnumerator PlayDialogues()
    {
        foreach (DialogueData data in dialogueRoot.dialogueDatas)
        {
            if (!this.enabled) 
            {
                yield return new WaitUntil(() => this.enabled);
            }
            yield return StartCoroutine(NormalChat(data));
        }
    }

    IEnumerator NormalChat(DialogueData data)
    {
        CharacterName.text = data.character;
        ChatText.fontSize = data.fontSize;
        writerText = "";

        if (data.character == "타마마") {
            emptyImage.sprite = changeSprite;
        }

        for (int i = 0; i < data.text.Length; i++)
        {
            if (!this.enabled) 
            {
                yield return new WaitUntil(() => this.enabled);
            }
            writerText += data.text[i];
            ChatText.text = writerText;
            yield return new WaitForSeconds(1f/data.textSpeed);
        }

        while (true)
        {
            if (!this.enabled) 
            {
                yield return new WaitUntil(() => this.enabled);
            }
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
            {
                break;
            }
            yield return null;
        }
    }
}
