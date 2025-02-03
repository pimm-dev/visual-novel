using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using ProtoBuf;

[Serializable]
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
    public MasterAudioMixerModel masterAudioMixer;
    
    private PlayerData()
    {
        this.playerName = PlayerDataDefaults.PLAYER_NAME;
        this.masterAudioMixer = new MasterAudioMixerModel();
    }

    public static string _getSerializationPath(string path = "")
    {
        if (path == "")
        {
            path = Path.Combine(Application.dataPath, BinarySerializationSupportsDefaults.PLAYER_DATA_SERIALIZATION_PATH);
        }
        else
        {
            path = Path.Combine(Application.dataPath, path);
        }
        return path;
    }

    public PlayerData Serialize(string path = "")
    {
        path = _getSerializationPath(path);

        using (FileStream file = File.Create(path))
        {
            Serializer.Serialize(file, this);
        }
        return this;
    }

    public PlayerData Deserialize(string path = "")
    {
        PlayerData _new;
        path = _getSerializationPath(path);

        try
        {
            using (FileStream file = File.OpenRead(path))
            {
                _new = Serializer.Deserialize<PlayerData>(file);
            }
        }
        catch (FileNotFoundException)
        {
            Serialize();
            return this;
        }

        this.playerName = _new.playerName;
        this.masterAudioMixer = _new.masterAudioMixer;
        return this;
    }

    public Task<PlayerData> SerializeAsync(string path = "")
    {
        return Task.Run(() => Serialize(path));
    }

    public Task<PlayerData> DeserializeAsync(string path = "")
    {
        return Task.Run(() => Deserialize(path));
    }
}
