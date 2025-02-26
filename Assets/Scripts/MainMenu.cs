using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public EventSystem ev;
    public GameObject target;

    private bool isSelected = false;

    void Update()
    {
        if( Input.GetAxisRaw("Vertical") != 0f && !isSelected ){
            ev.SetSelectedGameObject(target);
            isSelected = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject currentSelected = ev.currentSelectedGameObject;

            if (currentSelected != null)
            {
                Button button = currentSelected.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.Invoke();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();      
        }
    }

    private void OnDisable(){
            isSelected = false;
        }

    public void PlayGame()
    {
        SceneManager.LoadScene("NameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
