using System;

namespace DialogueControllers.Options
{
    public enum EachDialogueEndsAction
    {
        Suspend,
        Continue
    }

    [Serializable]
    public class DialogueControllerOptions
    {
        public EachDialogueEndsAction eachDialogueEndsAction;
        public float writtingCharacterInterval;
        public float startNextDialogueDelayWhenAutoWritting;
        public DialogueControllerOptions()
        {
            eachDialogueEndsAction = DialogueControllerOptionsDefaults.EACH_DIALOGUE_ENDS_ACTION;
            writtingCharacterInterval = DialogueControllerOptionsDefaults.WRITTING_CHARACTER_INTERVAL;
            startNextDialogueDelayWhenAutoWritting = DialogueControllerOptionsDefaults.START_NEXT_DIALOGUE_DELAY_WHEN_AUTO_WRITTING;
        }
    }
}
