using UnityEngine;

public class DialogueLoaderDebugger : MonoBehaviour
{
    public SerializableDialogueFlow dialogueFlow;
    
    [ContextMenu("Load Dialogue Flow v2")]
    public void LoadDialogueFlow()
    {
        Debug.Log("Loading dialogue flow...");
        dialogueFlow = DialogueLoader.LoadDialogueFlow("1", "2") as SerializableDialogueFlow;
        Debug.Log("Loaded dialogue flow: " + dialogueFlow.dialogueTablePostfix);
    }
}
