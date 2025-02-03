using System;
using ProtoBuf;

[Serializable]
[ProtoContract]
public class MasterAudioMixerModel : ICloneable
{

    [ProtoMember(1)] public AudioMixerModel master;
    [ProtoMember(2)] public AudioMixerModel music;

    [ProtoMember(3)] public AudioMixerModel sfx;
    
    [ProtoMember(4)] public AudioMixerModel dialogue;
    public MasterAudioMixerModel()
    {
        master = new AudioMixerModel(MasterAudioMixerDefaults.MASTER_VOLUME);
        music = new AudioMixerModel(MasterAudioMixerDefaults.MUSIC_VOLUME);
        sfx = new AudioMixerModel(MasterAudioMixerDefaults.SFX_VOLUME);
        dialogue = new AudioMixerModel(MasterAudioMixerDefaults.DIALOGUE_VOLUME);
    }

    public object Clone()
    {
        return new MasterAudioMixerModel
        {
            master = (AudioMixerModel)master.Clone(),
            music = (AudioMixerModel)music.Clone(),
            sfx = (AudioMixerModel)sfx.Clone(),
            dialogue = (AudioMixerModel)dialogue.Clone()
        };
    }

    public void PushStateToPlayerData()
    {
        PlayerData.I.masterAudioMixer = (MasterAudioMixerModel)Clone();
    }

    public void PullStateFromPlayerData()
    {
        MasterAudioMixerModel playerDataMasterAudioMixer = PlayerData.I.masterAudioMixer;
        master = (AudioMixerModel)playerDataMasterAudioMixer.master.Clone();
        music = (AudioMixerModel)playerDataMasterAudioMixer.music.Clone();
        sfx = (AudioMixerModel)playerDataMasterAudioMixer.sfx.Clone();
        dialogue = (AudioMixerModel)playerDataMasterAudioMixer.dialogue.Clone();
    }

    public void PushStateToPlayerDataAndSave()
    {
        PushStateToPlayerData();
        PlayerData.I.Serialize();
    }

    public void LoadAndPullStateFromPlayerData()
    {
        PlayerData.I.Deserialize();
        PullStateFromPlayerData();
    }
}
