using UnityEngine;
using LS = LocalizationSupports;

public class CharacterDefinition
{
    private const string _T = LocalizationTableKeys.CHARACTERS_TABLE;
    public string characterID { get; }
    public string displayI18nID { get; }
    public string spritePath { get; }
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
    
    public Sprite sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = Resources.Load(spritePath) as Sprite;
            }
            return _sprite;
        }
    }
}
