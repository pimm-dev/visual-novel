using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionController : MonoBehaviour
{
    public GameObject Option;
    public GameObject cc;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cc.GetComponent<Chat>().enabled = false;
            Option.SetActive(true);
        }
        if (!Option.activeSelf)
        {
            cc.GetComponent<Chat>().enabled = true;
        }
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
