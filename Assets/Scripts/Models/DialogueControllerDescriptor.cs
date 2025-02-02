using System;
using ProtoBuf;

[Serializable]
[ProtoContract]
public class DialogueControllerDescriptor : ICloneable
{
    [ProtoMember(1)]
    public bool enabled;
    [ProtoMember(2)]
    public string currentChapter;
    [ProtoMember(3)]
    public string currentDialogueFlowID;
    [ProtoMember(4)]
    public string currentDialogueID;

    public DialogueControllerDescriptor()
    {
        // Refer: Assets/Scripts/Definitions/DialogueControllerDefaults.cs
        enabled = DialogueControllerDescriptorDefaults.ENABLED;
        currentDialogueFlowID = DialogueControllerDescriptorDefaults.CURRENT_DIALOGUE_FLOW_ID;
        currentDialogueID = DialogueControllerDescriptorDefaults.CURRENT_DIALOGUE_ID;
        currentChapter = DialogueControllerDescriptorDefaults.CURRENT_CHAPTER;
    }

    public DialogueControllerDescriptor(bool enabled, string currentChapter, string currentDialogueID)
    {
        enabled = enabled;
        currentChapter = currentChapter;
        currentDialogueFlowID = currentDialogueFlowID;
        currentDialogueID = currentDialogueID;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
