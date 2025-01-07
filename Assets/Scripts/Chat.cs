using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Chat : MonoBehaviour
{
    public Image emptyImage;
    public Image left;
    public Image right;
    public Sprite Elina;
    public Sprite Cecilia;
    public Sprite Sophia;
    public Sprite Coco;
    public Sprite Empty;

    public Image main;

    private Dictionary<string, Sprite> backgroundSprites;

    public Sprite Bg1;
    public Sprite black;
    public Sprite bed;
    public Sprite classtest;
    public Sprite classroom;
    public Sprite campus;

    public TMPro.TMP_Text ChatText;
    public TMPro.TMP_Text CharacterName;

    public string writerText = "";

    private JsonData dialogueRoot;
    private GameObject namebox;

    private bool isAutoMode = false;
    public float autoChatDelay = 1f;

    private bool isSkip = false;
    private bool isTyping = false;
    private bool canInput = true;
    public Button AutoModeButton;
    private ColorBlock originalColors;

    void Start()
    {
        namebox = GameObject.Find("Name");
        InitializeBackgroundSprites();
        LoadDialogueData("dgData.json");
        ApplyPlayerName();
        StartCoroutine(PlayDialogues());

        originalColors = AutoModeButton.colors;
    }

    void Update() 
    {
        if (isTyping && canInput && !isAutoMode)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
            {  
                isSkip = true;
                canInput = false;
            }
        }
    }

    void InitializeBackgroundSprites()
    {
        backgroundSprites = new Dictionary<string, Sprite>
        {
            {"school1", Bg1},
            {"black", black},
            {"bed", bed},
            {"classtest", classtest},
            {"classroom", classroom},
            {"campus", campus}
        };
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

    void ApplyPlayerName()
    {
        string playerName = PlayerPrefs.GetString("Name", "inputName");

        foreach (var scene in dialogueRoot.scenes)
        {
            foreach (var dialogue in scene.dialogueDatas)
            {
                if (dialogue.text.Contains("{PlayerName}"))
                {
                    dialogue.text = dialogue.text.Replace("{PlayerName}", playerName);
                }
                if (dialogue.character == "{PlayerName}")
                {
                    dialogue.character = dialogue.character.Replace("{PlayerName}", playerName);
                }
            }
        }
    }

    IEnumerator PlayDialogues()
    {
        foreach (var scene in dialogueRoot.scenes)
        {
            if (backgroundSprites.ContainsKey(scene.background))
            {
                main.sprite = backgroundSprites[scene.background];
            }
    
            foreach (DialogueData data in scene.dialogueDatas)
            {
                if (!this.enabled) 
                {
                    yield return new WaitUntil(() => this.enabled);
                }
                yield return StartCoroutine(NormalChat(data));
            }
        }
    }

    IEnumerator NormalChat(DialogueData data)
    {
        if (data.character == "나레이션") {
            namebox.SetActive(false);
        } 
        else {
            namebox.SetActive(true);
            CharacterName.text = data.character;
        }

        if (data.character == "엘리나") {
            if (data.position == "left") {
                emptyImage.sprite = Empty;
                left.sprite = Elina;
            }
            else if (data.position == "right") {
                emptyImage.sprite = Empty;
                right.sprite = Elina;
            }
            else
                emptyImage.sprite = Elina;
        }
        else if (data.character == "세실리아") {
            if (data.position == "left") {
                emptyImage.sprite = Empty;
                left.sprite = Cecilia;
            }
            else if (data.position == "right") {
                emptyImage.sprite = Empty;
                right.sprite = Cecilia;
            }
            else
                emptyImage.sprite = Cecilia;
        }
        else if (data.character == "소피아") {
            if (data.position == "left") {
                emptyImage.sprite = Empty;
                left.sprite = Sophia;
            }
            else if (data.position == "right") {
                emptyImage.sprite = Empty;
                right.sprite = Sophia;
            }
            else
                emptyImage.sprite = Sophia;
        }
        else if (data.character == "코코") {
            if (data.position == "left") {
                emptyImage.sprite = Empty;
                left.sprite = Coco;
            }
            else if (data.position == "right") {
                emptyImage.sprite = Empty;
                right.sprite = Coco;
            }
            else
                emptyImage.sprite = Coco;
        }
        else if (data.character == "나레이션" || data.character == "교수") {
            emptyImage.sprite = Empty;
            left.sprite = Empty;
            right.sprite = Empty;
        }
       
        ChatText.fontSize = data.fontSize;
        writerText = "";
        isTyping = true;
        canInput = true;

        for (int i = 0; i < data.text.Length; i++)
        {
            if (!this.enabled) 
            {
                yield return new WaitUntil(() => this.enabled);
            }

            if(isSkip)
            {
                writerText = data.text;
                ChatText.text = writerText;
                break;
            }

            writerText += data.text[i];
            ChatText.text = writerText;
            yield return new WaitForSeconds(1f/data.textSpeed);
        }

        isTyping = false;
        isSkip = false;
        if (data.text != "")
            yield return new WaitForSeconds(0.1f);
        canInput = true;

        float autoTimer = 0f;
        while (true)
        {
            if (!this.enabled) 
            {
                yield return new WaitUntil(() => this.enabled);
            }
            
            if (isAutoMode)
            {
                autoTimer += Time.deltaTime;
                if (data.text == "")
                    autoTimer = autoChatDelay;
                if (autoTimer >= autoChatDelay)
                    break;
            }
            else 
            {
                autoTimer = 0f;
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
                {
                    break;
                }
            }
            yield return null;
        }
    }

    public void AutoMode()
    {   
        isAutoMode = !isAutoMode;
        Debug.Log($"Auto Mode: {isAutoMode}");

        ColorBlock colors = originalColors;
        if (isAutoMode)
        {
            colors.normalColor = originalColors.selectedColor;
        }
        else
        {
            colors.normalColor = originalColors.normalColor;
            colors.selectedColor = originalColors.normalColor;
        }
        AutoModeButton.colors = colors;
    }
}
