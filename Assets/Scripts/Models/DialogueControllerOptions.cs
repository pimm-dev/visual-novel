using System;

namespace DialogueControllers.Options
{
    public enum EachDialogueEndsAction
    {
        Suspend,
        Continue
    }

    public enum SerializingDescriptorTiming
    {
        OnEnabledChanged = 1 << 0,
        OnDialogueStarted = 1 << 1,
        OnDialogueEnded = 1 << 2,
        OnDialogueFlowChanged = 1 << 3,
    }

    [Serializable]
    public class DialogueControllerOptions
    {
        public EachDialogueEndsAction eachDialogueEndsAction;
        public float writtingCharacterInterval;
        public float startNextDialogueDelayWhenAutoWritting;
        public SerializingDescriptorTiming serializingdescriptorTiming;
        public DialogueControllerOptions()
        {
            eachDialogueEndsAction = DialogueControllerOptionsDefaults.EACH_DIALOGUE_ENDS_ACTION;
            writtingCharacterInterval = DialogueControllerOptionsDefaults.WRITTING_CHARACTER_INTERVAL;
            startNextDialogueDelayWhenAutoWritting = DialogueControllerOptionsDefaults.START_NEXT_DIALOGUE_DELAY_WHEN_AUTO_WRITTING;
            serializingdescriptorTiming = DialogueControllerOptionsDefaults.SERIALIZING_DESCRIPTOR_TIMING;
        }
    }
}
