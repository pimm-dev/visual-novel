using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class OptionController : MonoBehaviour
{
    public GameObject Option;
    public GameObject cc;
    private bool canEnter = false;
    public GameObject savePanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cc.GetComponent<Chat>().enabled = false;
            Option.SetActive(true);
        }
        if (!Option.activeSelf && canEnter)
        {
            cc.GetComponent<Chat>().enabled = true;
            canEnter = false;
        }
        if (savePanel.activeSelf)
        {
            SavePanelOff();
        }
    }

    public void Back() {
        StartCoroutine(BackCoroutine());
    }

    public void SavePanelOff()
    {
        StartCoroutine(PanelCoroutine());
    }

    private IEnumerator BackCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        canEnter = true;
    }

    private IEnumerator PanelCoroutine()
    {
        yield return new WaitForSeconds(1f);
        savePanel.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
