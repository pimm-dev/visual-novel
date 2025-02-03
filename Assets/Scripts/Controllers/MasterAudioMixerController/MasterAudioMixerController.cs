using UnityEngine;
using UnityEngine.Audio;

using Mixer = EAudioMixerGroupSupports;
using Group = EAudioMixerGroups;

public class MasterAudioMixerController : MonoBehaviour
{
    public static MasterAudioMixerController Instance { get; private set; }

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private MasterAudioMixerModel masterAudioMixerModel;

    private void Awake()
    {
        _InitObject();
    }

    private void Start()
    {
        _SyncState();
    }

    private void _InitObject()
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
        masterAudioMixerModel = new MasterAudioMixerModel();
    }

    [ContextMenu("Apply state to master audio mixer")]
    public void ApplyStateToMasterAudioMixer()
    {
        audioMixer.SetFloat(Mixer._G(Group.Master), masterAudioMixerModel.master.volume);
        audioMixer.SetFloat(Mixer._G(Group.Music), masterAudioMixerModel.music.volume);
        audioMixer.SetFloat(Mixer._G(Group.SFX), masterAudioMixerModel.sfx.volume);
    }

    private void _SyncState()
    {
        ApplyStateToMasterAudioMixer();
    }
}
