using UnityEngine;
using I18nSupport;

private I18n i18n = I18n.Instance;

public class Character
{
    public string characterID { get; };
    public string displayI18nID { get; };
    public string spritePath { get; };
    private Sprite _sprite { get; };

    public Character(
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
            i18n.__(this.displayI18nID);
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
