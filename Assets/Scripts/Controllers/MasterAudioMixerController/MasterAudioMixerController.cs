using UnityEngine;
using UnityEngine.Audio;

using Mixer = EAudioMixerGroupSupports;
using Group = EAudioMixerGroups;

public class MasterAudioMixerController : MonoBehaviour
{
    public static MasterAudioMixerController Instance { get; private set; }

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] public MasterAudioMixerModel masterAudioMixerModel;

    private void Awake()
    {
        _InitObject();
    }

    private void Start()
    {
        PushStateToMasterAudioMixer();
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
        masterAudioMixerModel = MasterAudioMixerModel.LoadFromPlayerData();
    }

    public void PushStateToMasterAudioMixer()
    {
        audioMixer.SetFloat(Mixer._G(Group.Master), masterAudioMixerModel.master.volume);
        audioMixer.SetFloat(Mixer._G(Group.Music), masterAudioMixerModel.music.volume);
        audioMixer.SetFloat(Mixer._G(Group.SFX), masterAudioMixerModel.sfx.volume);
    }

    public void PullStateFromMasterAudioMixer()
    {
        audioMixer.GetFloat(Mixer._G(Group.Master), out masterAudioMixerModel.master.volume);
        audioMixer.GetFloat(Mixer._G(Group.Music), out masterAudioMixerModel.music.volume);
        audioMixer.GetFloat(Mixer._G(Group.SFX), out masterAudioMixerModel.sfx.volume);
    }

    public void PushStateToPlayerData()
    {
        masterAudioMixerModel.PushStateToPlayerData();
    }

    public void PullStateFromPlayerData()
    {
        masterAudioMixerModel.PullStateFromPlayerData();
    }

    public void PushStateToPlayerDataAndSave()
    {
        masterAudioMixerModel.PushStateToPlayerDataAndSave();
    }

    public void LoadAndPullStateFromPlayerData()
    {
        masterAudioMixerModel.LoadAndPullStateFromPlayerData();
    }
}
