using UnityEngine;
using UnityEngine.Audio;

using Mixer = EAudioMixerGroupSupports;
using Group = EAudioMixerGroups;

public class MasterAudioMixerController : MonoBehaviour
{
    public static MasterAudioMixerController Instance { get; private set; }

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private MasterAudioMixerModel masterAudioMixerModel = new MasterAudioMixerModel();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [ContextMenu("Debug exposed value")]
    public void DebugAudioMixerExposedValue()
    {
        audioMixer.GetFloat(Mixer._G(Group.Master), out masterAudioMixerModel.master.volume);
        audioMixer.GetFloat(Mixer._G(Group.Music), out masterAudioMixerModel.music.volume);
        audioMixer.GetFloat(Mixer._G(Group.SFX), out masterAudioMixerModel.sfx.volume);
    }
}