using UnityEngine;

public class MainMusicAudioSourceController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        InitializePropertiesOnAwake();
    }

    private void InitializePropertiesOnAwake()
    {
        audioSource.volume = MainMusicAudioSourceControllerDefaults.INIT_VOLUME;
        audioSource.loop = MainMusicAudioSourceControllerDefaults.INIT_LOOP;
        audioSource.playOnAwake = MainMusicAudioSourceControllerDefaults.INIT_PLAY_ON_AWAKE;
    }
}
