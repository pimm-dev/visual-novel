using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameScript : MonoBehaviour
{
    public TMPro.TMP_InputField inputName;

    public void Save()
    {
        PlayerPrefs.SetString("Name", inputName.text);
        SceneManager.LoadScene("Game");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
        Save();
    }
    

}
