using System;

[Serializable]
public class AudioMixerModel
{
    [UnityEngine.Range(AudioMixerDefaults.VOLUME_MIN, AudioMixerDefaults.VOLUME_MAX)] public float volume;
    public AudioMixerModel()
    {
        volume = AudioMixerDefaults.VOLUME;
    }
    public AudioMixerModel(float volume)
    {
        this.volume = volume;
    }
}
