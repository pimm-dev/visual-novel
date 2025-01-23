public class DialogueControllerConfig
{
    public bool isAutoMode;
    public float autoModeDelay;
    public DialogueControllerConfig()
    {
        isAutoMode = DialogueControllerConfigDefaults.isAutoMode;
        autoModeDelay = DialogueControllerConfigDefaults.autoModeDelay;
    }
}
