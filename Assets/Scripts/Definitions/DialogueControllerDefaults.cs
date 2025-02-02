using DialogueControllers.Options;
public class DialogueControllerDescriptorDefaults
{
    public const bool ENABLED = false;
    /**
     * CURRENT_CHAPTER is used to initialize the current chapter value.
     * It's "current", but it's actually the initial chapter.
     * (Current chapter is the chapter that is currently being processed.)
     */
    /**
     * NOTICE: CURRENT_CHAPTER must be one of value defined in `DialogueControllerLogicPlaceholders.GetNextChapterID`.
     * If not, the dialogue will be continued until the end of the dialogue internally.
     * Because the `DialogueControllerLogicPlaceholders.GetNextChapterID` is a temporary placeholder,
     * the value of CURRENT_CHAPTER should be updated after the implementation of the logic.
     *
     * Refer: Assets/Scripts/Definitions/DialogueControllerPlaceholders.cs
     */
    public const string CURRENT_CHAPTER = "1";
    public const string CURRENT_DIALOGUE_FLOW_ID = "";
    public const string CURRENT_DIALOGUE_ID = "";
}

public class DialogueControllerOptionsDefaults
{
    public const EachDialogueEndsAction EACH_DIALOGUE_ENDS_ACTION = EachDialogueEndsAction.Suspend;
    public const float WRITTING_CHARACTER_INTERVAL = .5f;
    public const float START_NEXT_DIALOGUE_DELAY_WHEN_AUTO_WRITTING = 1f;
}
