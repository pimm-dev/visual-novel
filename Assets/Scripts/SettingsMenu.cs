using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public EventSystem ev;
    public GameObject target;
    public GameObject quitPanel;
    private bool isSelected = false;

    [SerializeField] private GameObject masterAudioMixerControllerObject;
    [SerializeField] private MasterAudioMixerController masterAudioMixerController;
    void Awake()
    {
        _LoadMasterAudioMixerController();
    }

    void _LoadMasterAudioMixerController()
    {
        if (masterAudioMixerControllerObject == null)
        {
            masterAudioMixerControllerObject = GameObject.Find(MasterAudioMixerDefaults.PREFAB_NAME);
        }
        if (masterAudioMixerController == null)
        {
            masterAudioMixerController = masterAudioMixerControllerObject.GetComponent<MasterAudioMixerController>();
        }
    }

    void Start()
    {
        // Screen resolution
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        resolutionDropdown.RefreshShownValue();

        // Audio levels
        /**
         * NOTE: First MasterAudioMixerController.PushStateToMasterAudioMixer() calling
         *       is in the Start() method. Keep in mind when adjust initialization order.
         */
    }

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
    }

    public void QuitPanelOff(){
        isSelected = false;
    }

    private void OnDisable(){
            isSelected = false;
        }
        
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    /*
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
    }
    */

    public void SetResolution(int resulutionIndex)
    {
        string[] resolutionText = resolutionDropdown.options[resulutionIndex].text.Split('x');
        int width = int.Parse(resolutionText[0].Trim());
        int height = int.Parse(resolutionText[1].Trim());
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        /**
         * NOTE: Sets the volume of the master audio mixer.
         *       If there are requirements to set the each volume of the audio mixer,
         *       then modify the following code:
         */
        masterAudioMixerController.masterAudioMixerModel.master.volume = volume;
        masterAudioMixerController.PushStateToMasterAudioMixer();
        masterAudioMixerController.PushStateToPlayerDataAndSave();
        // audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
