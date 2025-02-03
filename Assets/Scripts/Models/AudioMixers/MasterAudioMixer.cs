using System;

[Serializable]
public class MasterAudioMixerModel
{
    public AudioMixerModel master;
    public AudioMixerModel music;
    public AudioMixerModel sfx;
    public AudioMixerModel dialogue;
    public MasterAudioMixerModel()
    {
        master = new AudioMixerModel(MasterAudioMixerDefaults.MASTER_VOLUME);
        music = new AudioMixerModel(MasterAudioMixerDefaults.MUSIC_VOLUME);
        sfx = new AudioMixerModel(MasterAudioMixerDefaults.SFX_VOLUME);
        dialogue = new AudioMixerModel(MasterAudioMixerDefaults.DIALOGUE_VOLUME);
    }
}
