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
        master = new AudioMixerModel(AudioMixerDefaults.VOLUME);
        music = new AudioMixerModel(AudioMixerDefaults.VOLUME);
        sfx = new AudioMixerModel(AudioMixerDefaults.VOLUME);
        dialogue = new AudioMixerModel(AudioMixerDefaults.VOLUME);
    }
}
