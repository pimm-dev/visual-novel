using System;
using ProtoBuf;

[Serializable]
[ProtoContract]
public class AudioMixerModel : ICloneable
{
    [UnityEngine.Range(AudioMixerDefaults.VOLUME_MIN, AudioMixerDefaults.VOLUME_MAX)]
    [ProtoMember(1)]
    public float volume;

    public AudioMixerModel()
    {
        volume = AudioMixerDefaults.VOLUME;
    }
    public AudioMixerModel(float volume)
    {
        this.volume = volume;
    }

    public object Clone()
    {
        return new AudioMixerModel
        {
            volume = volume
        };
    }
}
