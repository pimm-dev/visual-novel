using DialogueControllers.Options;

public class DialogueControllerOptionsDefaults
{
    public const EachDialogueEndsAction EACH_DIALOGUE_ENDS_ACTION = EachDialogueEndsAction.Suspend;
    public const float WRITTING_CHARACTER_INTERVAL = .5f;
    public const float START_NEXT_DIALOGUE_DELAY_WHEN_AUTO_WRITTING = 1f;
    public const SerializingDescriptorTiming SERIALIZING_DESCRIPTOR_TIMING = SerializingDescriptorTiming.OnEnabledChanged | SerializingDescriptorTiming.OnDialogueFlowChanged;
}
