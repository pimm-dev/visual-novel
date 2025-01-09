using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public static string LoadID = "d1";

    public void GameSave()
    {
        PlayerPrefs.SetString("ID", Chat.currentID);
        PlayerPrefs.Save();
    }

    public static void GameLoad()
    {
        LoadID = PlayerPrefs.GetString("ID");
        SceneManager.LoadScene("Game");
    }
}
