using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using ProtoBuf;

public class BinarySerializationSupports {}

public static class PlayerDataBinarySerializationExtension
{
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

    public static PlayerData Serialize(this PlayerData playerData, string path = "")
    {
        path = PlayerDataBinarySerializationExtension._getSerializationPath(path);

        using (FileStream file = File.Create(path))
        {
            Serializer.Serialize(file, playerData);
        }
        return playerData;
    }

    public static PlayerData Deserialize(this PlayerData playerData, string path = "")
    {
        path = PlayerDataBinarySerializationExtension._getSerializationPath(path);

        using (FileStream file = File.OpenRead(path))
        {
            playerData = Serializer.Deserialize<PlayerData>(file);
        }
        return playerData;
    }

    public static Task<PlayerData> SerializeAsync(this PlayerData playerData, string path = "")
    {
        return Task.Run(() => playerData.Serialize(path));
    }

    public static Task<PlayerData> DeserializeAsync(this PlayerData playerData, string path = "")
    {
        return Task.Run(() => playerData.Deserialize(path));
    }
}
