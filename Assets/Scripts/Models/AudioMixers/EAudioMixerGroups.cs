using System;

public enum EAudioMixerGroups
{
    Master,
    Music,
    SFX,
    Dialogue,  // TODO
}

public class EAudioMixerGroupSupports
{
    public static string GetAudioMixerGroupString(EAudioMixerGroups audioMixerGroup)
    {
        switch (audioMixerGroup)
        {
            case EAudioMixerGroups.Master:
                return EAudioMixerGroupDefaults.MASTER_VOLUME_STRING;
            case EAudioMixerGroups.Music:
                return EAudioMixerGroupDefaults.MUSIC_VOLUME_STRING;
            case EAudioMixerGroups.SFX:
                return EAudioMixerGroupDefaults.SFX_VOLUME_STRING;
            case EAudioMixerGroups.Dialogue:
                return EAudioMixerGroupDefaults.DIALOGUE_VOLUME_STRING;
            default:
                throw new ArgumentException("Invalid audio mixer group.");
        }
    }

    public static string _G(EAudioMixerGroups audioMixerGroup) => GetAudioMixerGroupString(audioMixerGroup);
}
