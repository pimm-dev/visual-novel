/**
 * ACTION REQUIRED:
 * This script is not recommended type of script to be written.
 * When refactor scripts, make sure to migrate this to others.
 *
 * What the hell is this?
 * This is a simple initializer for UnityEngine.UI.Slider component.
 * It is used to set the value of the slider to the value of the master audio mixer.
 * On value change handler is implemented in the other script.
 * (Refer inspector on Unity Editor and scripts)
 *
 * Why this code is seperated?
 * Refactoring is work in progress at the other branch.
 * And refactoring seperately is not good idea I think.
 *
 * Then what should I do?
 * I don't know. If there is afford to refactor, then refactor and remove this script.
 */

using UnityEngine;
using UnityEngine.UI;

public class SettingsUI__AudioVolumeSliderController : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private GameObject masterAudioMixerControllerObject;
    [SerializeField] private MasterAudioMixerController masterAudioMixerController;
    void Awake()
    {
        _LoadMasterAudioMixerController();
        _LoadMasterVolumeSlider();
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

    void _LoadMasterVolumeSlider()
    {
        if (masterVolumeSlider == null)
        {
            masterVolumeSlider = GetComponent<Slider>();
        }
    }

    void Start()
    {
        masterVolumeSlider.value = masterAudioMixerController.masterAudioMixerModel.master.volume;
    }
}
