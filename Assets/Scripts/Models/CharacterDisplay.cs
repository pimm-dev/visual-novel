using System.Collections;
using System.Collections.Generic;

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

public class CharacterDisplayEachScene: List<CharacterDisplay> {}

/**
 * TODO: Placeholder for simple character animation.
 * i.e. Move character from left to right, etc.
 * Implementation would be worked with easing within specific time duration.
 * 
 * Before the implementation, instance's length of this class should be 1.
 */
public class CharacterDisplayKeyFrame: List<CharacterDisplayEachScene> {}
