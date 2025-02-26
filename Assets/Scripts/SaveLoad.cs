using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public static string LoadID = "d1";
    public static string LoadName;

    public void GameSave()
    {
        PlayerPrefs.SetString("ID", Chat.currentID);
        PlayerPrefs.SetString("LoadName", Chat.playerName);
        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        LoadID = PlayerPrefs.GetString("ID", "d1");
        LoadName = PlayerPrefs.GetString("LoadName", "defaultName");
        if (LoadName == "defaultName")
            return;
        Chat.playerName = LoadName;
        SceneManager.LoadScene("Game");
    }
}
