/**
 * CharacterRegistry is used to define the characters resources in the game.
 * Below Character instance as a CharacterRegistry's property is for defintion
 * for using in the game, and CharacterRegistry is NOT INTENDED to be instantiated.
 *
 * All of characters used by the dialogue should be defined here.
 */
public class CharacterRegistry
{
    public static CharacterDefinition elina = new CharacterDefinition("elina", "ELINA.DISPLAY_NAME", "Sprites/Characters/Elina");
    public static CharacterDefinition cecilia = new CharacterDefinition("cecilia", "CECILIA.DISPLAY_NAME", "Sprites/Characters/Cecilia");
    public static CharacterDefinition sophia = new CharacterDefinition("sophia", "SOPHIA.DISPLAY_NAME", "Sprites/Characters/Sophia");
    public static CharacterDefinition coco = new CharacterDefinition("coco", "COCO.DISPLAY_NAME", "Sprites/Characters/Coco");

    // Specific control needed
    public static CharacterDefinition player = new CharacterDefinition("player", "PLAYER.DISPLAY_NAME", "Sprites/Characters/Player");

    public static CharacterDefinition undefined = new CharacterDefinition("undefined", "UNDEFINED.DISPLAY_NAME", "__TODO__");

    /**
     * Index
     */
    public static CharacterDefinition Get(string characterID)
    {
        switch (characterID.ToLower())
        {
            case "elina":
                return elina;
            case "cecilia":
                return cecilia;
            case "sophia":
                return sophia;
            case "coco":
                return coco;
            default:
                return undefined;
        }
    }
}
