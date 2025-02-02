using UnityEngine;

public class BinarySerializationSupportsDebugger : MonoBehaviour
{
    public PlayerData playerData = PlayerData.I;
    
    [ContextMenu("Serialize PlayerData")]
    public void SerializePlayerData()
    {
        playerData.Serialize();
    }

    [ContextMenu("Deserialize PlayerData")]
    public void DeserializePlayerData()
    {
        playerData = playerData.Deserialize();
    }
}
