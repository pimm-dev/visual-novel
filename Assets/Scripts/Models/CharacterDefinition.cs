using System.IO;
using UnityEngine;
using LS = LocalizationSupports;

public class CharacterDefinition
{
    private const string _T = LocalizationTableKeys.CHARACTERS_TABLE;
    public string characterID { get; }
    public string displayI18nID { get; }
    public string spritePath { get; }
    private Texture2D _texture;
    private Sprite _sprite;

    public CharacterDefinition(
        string characterID,
        string displayI18nID,
        string spritePath
    )
    {
        this.characterID = characterID;
        this.displayI18nID = displayI18nID;
        this.spritePath = spritePath;
    }

    public string DisplayName
    {
        get
        {
            return LS.__(_T, this.displayI18nID);
        }
    }
    
    public Texture2D texture
    {
        get
        {
            if (_texture == null)
            {
                string path = Path.Combine(Application.streamingAssetsPath, spritePath);
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"Sprite file({path}) not found.");
                }
                byte[] raw = File.ReadAllBytes(path);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(raw);
                _texture = texture;
            }
            return _texture;
        }
    }

    public Sprite sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f),
                    100
                );
            }
            return _sprite;
        }
    }
}
