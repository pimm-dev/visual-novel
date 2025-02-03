# AudioMixers

Represents the audio mixers in the game.

If there are requirements for adjusting the audio levels in the game, control volume through these models instead of directly through the audio sources.

Audio sources should be set in development. If there aren't features that each game object that sounds should be controlled individually, controlling audio source component dynamically is not recommended.

Set audio source properties statically as much as possible. Refer [`Scripts/Controllers/AudioController.cs`](../Controllers/AudioController.cs).

## How to work

MasterAudioMixer controls the root audio mixer. It represents the each audio mixer group (`AudioMixerModel`).

For now, it just initializes the audio mixer groups' properties and makes sure that the audio level is set correctly.

If there are requirements for controlling the audio mixer groups, add the properties and methods to the `AudioMixerModel`.

```
- MasterAudioMixerModel
  - AudioMixerModel master
    - float volume
  - AudioMixerModel music
  - AudioMixerModel sfx
```

The `MasterAudioMixerModel` would be instantiated by `MasterAudioMixerController` instance and game object. Because the object makes singleton object itself and runs throughout the runtime, It is not necessary to place the `MasterAudioMixerModel` in the scene except entry point scene. But if you want to see the working status during the development in the other scenes, you can place it in the scene. (It doesn't matter.)
