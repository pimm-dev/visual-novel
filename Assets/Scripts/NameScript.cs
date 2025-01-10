using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameScript : MonoBehaviour
{
    public TMPro.TMP_InputField inputName;
    public GameObject nullpanel;

    public void Save()
    {
        if (inputName.text == "")
        {
            nullpanel.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("NewName", inputName.text);
            PlayerPrefs.Save();
            Chat.playerName = inputName.text;
            SceneManager.LoadScene("Game");
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
            Save();
    }
    

}
