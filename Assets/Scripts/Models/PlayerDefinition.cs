public class PlayerDefinition
{
    public string displayName { get; private set; }
    public PlayerDefinition(string displayName)
    {
        this.displayName = displayName;
    }
}
