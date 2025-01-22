using UnityEngine;

/**
 * CharacterRegistry is used to define the characters resources in the game.
 * Below Character instance as a CharacterRegistry's property is for defintion
 * for using in the game, and CharacterRegistry is NOT INTENDED to be instantiated.
 */
public class CharacterRegistry
{
    public static CharacterDefinition elina = new CharacterDefinition("elina", "elina.display_name", "Sprites/Characters/Elina");
    public static CharacterDefinition cecilia = new CharacterDefinition("cecilia", "cecilia.display_name", "Sprites/Characters/Cecilia");
    public static CharacterDefinition sophia = new CharacterDefinition("sophia", "sophia.display_name", "Sprites/Characters/Sophia");
    public static CharacterDefinition coco = new CharacterDefinition("coco", "coco.display_name", "Sprites/Characters/Coco");
}
