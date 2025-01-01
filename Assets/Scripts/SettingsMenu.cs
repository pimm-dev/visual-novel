using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
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
    }

    private void OnDisable(){
            isSelected = false;
        }
        
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    void Start()
    {
        // resolutions = Screen.resolutions;

        // resolutionDropdown.ClearOptions();

        // List<string> options = new List<string>();

        // int currentResolutionIndex = 0;

        // for (int i = 0; i < resolutions.Length; i++)
        // {
        //     string option = resolutions[i].width + " x " + resolutions[i].height;
        //     options.Add(option);
        //     if (resolutions[i].width == Screen.width &&
        //         resolutions[i].height == Screen.height)
        //     {
        //         currentResolutionIndex = i;
        //     }
        // }

        // resolutionDropdown.AddOptions(options);
        // resolutionDropdown.value = currentResolutionIndex;
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resulutionIndex)
    {
        string[] resolutionText = resolutionDropdown.options[resulutionIndex].text.Split('x');
        int width = int.Parse(resolutionText[0].Trim());
        int height = int.Parse(resolutionText[1].Trim());
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
