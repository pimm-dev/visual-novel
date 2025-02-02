using ProtoBuf;

[System.Serializable]
[ProtoContract]
public class PlayerData
{
    private static PlayerData _instance;
    public static PlayerData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerData();
            }
            return _instance;
        }
    }
    public static PlayerData I
    {
        get
        {
            return Instance;
        }
    }

    [ProtoMember(1)]
    public string playerName;
    [ProtoMember(2)]
    public DialogueControllerDescriptor dialogueControllerDescriptor;
    
    private PlayerData()
    {
        this.playerName = PlayerDataDefaults.PLAYER_NAME;
        this.dialogueControllerDescriptor = new DialogueControllerDescriptor();
    }
}
