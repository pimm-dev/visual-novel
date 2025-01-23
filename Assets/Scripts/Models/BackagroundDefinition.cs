using UnityEngine;

public class BackgroundDefinition
{
    public string backgroundID { get; }
    public string spritePath { get; }
    private Sprite _sprite;

    public BackgroundDefinition(
        string backgroundID,
        string spritePath
    )
    {
        this.backgroundID = backgroundID;
        this.spritePath = spritePath;
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