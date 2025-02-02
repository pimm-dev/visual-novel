/**
 * This container is for common used data for SmartString.
 * Intended usage: Call singleton instance and set the required data.
 */
/// <code>
/// SmartStringSupportsDataContainer.Instance.Player = player;
/// // or
/// SmartStringSupportsDataContainer.Instance.SetRequiredData(player);
/// </code>
public class SmartStringCommonUsedData
{
    public string PlayerDisplayName { get; private set; }

    public static SmartStringCommonUsedData Instance { get; } = new SmartStringCommonUsedData();
    private SmartStringCommonUsedData()
    {
    }

    public PlayerDefinition Player
    {
        set
        {
            PlayerDisplayName = value.displayName;
        }
    }
    public void SetRequiredData(PlayerDefinition player)
    {
        PlayerDisplayName = player.displayName;
    }
}

/**
 * TODO:
 *  - Add smart string caller field to serialize field.
 *  - Add handler for smart string caller to this file.
 */
// public class SmartStringSupports {}
