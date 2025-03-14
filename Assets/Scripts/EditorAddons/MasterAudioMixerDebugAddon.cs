#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MasterAudioMixerController))]
public class MasterAudioMixerControllerDebugAddon : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MasterAudioMixerController controller = (MasterAudioMixerController)target;
        if (GUILayout.Button("Push state to master audio mixer"))
        {
            controller.PushStateToMasterAudioMixer();
        }
        if (GUILayout.Button("Pull state from master audio mixer"))
        {
            controller.PullStateFromMasterAudioMixer();
        }
        if (GUILayout.Button("Serialize and save state"))
        {
            controller.PushStateToPlayerDataAndSave();
        }
        if (GUILayout.Button("Deserialize and load state"))
        {
            controller.LoadAndPullStateFromPlayerData();
        }
    }
}
#endif
