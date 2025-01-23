public enum CharacterPlacement
{
    Left,
    Middle,
    Right
}

public class CharacterDisplay
{
    public CharacterDefinition character;
    public CharacterPlacement placement;
    public CharacterDisplay
    (
        CharacterDefinition character,
        CharacterPlacement placement
    )
    {
        this.character = character;
        this.placement = placement;
    }
}
