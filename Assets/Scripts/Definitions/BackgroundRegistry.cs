/**
 * BackgroundRegistry is used to define the backgrounds resources in the game.
 * Below Background instance as a BackgroundRegistry's property is for defintion
 * for using in the game, and BackgroundRegistry is NOT INTENDED to be instantiated.
 */
public class BackgroundRegistry
{
    /**
     * Backgrounds
     */
    public static BackgroundDefinition black = new BackgroundDefinition("black", "Sprites/Backgrounds/Black.jpg");
    public static BackgroundDefinition hall = new BackgroundDefinition("hall", "Sprites/Backgrounds/Hall.png");
    public static BackgroundDefinition bedroom = new BackgroundDefinition("bedroom", "Sprites/Backgrounds/Bedroom.jpg");
    public static BackgroundDefinition classroom = new BackgroundDefinition("classroom", "Sprites/Backgrounds/Classroom.png");
    public static BackgroundDefinition testroom = new BackgroundDefinition("testroom", "Sprites/Backgrounds/Testroom.png");
    public static BackgroundDefinition campusOverview = new BackgroundDefinition("campus_overview", "Sprites/Backgrounds/CampusOverview.png");
    public static BackgroundDefinition forest = new BackgroundDefinition("forest", "Sprites/Backgrounds/Forest.png");
    public static BackgroundDefinition frontGate = new BackgroundDefinition("front_gate", "Sprites/Backgrounds/FrontGate.png");
    public static BackgroundDefinition hallway = new BackgroundDefinition("hallway", "Sprites/Backgrounds/Hallway.png");
    // TODO: Rename to "alchemyLab"
    public static BackgroundDefinition alchemy = new BackgroundDefinition("alchemy", "Sprites/Backgrounds/Alchemy.png");
    public static BackgroundDefinition empty = new BackgroundDefinition("empty", "Sprites/Backgrounds/Empty.png");

    /**
     * Aliases
     */
    public static BackgroundDefinition undefined = empty;

    /**
     * Index
     */
    public static BackgroundDefinition Get(string backgroundID)
    {
        switch (backgroundID.ToLower())
        {
            case "black":
                return black;
            case "hall":
                return hall;
            case "classroom":
                return classroom;
            case "testroom":
                return testroom;
            case "campus_overview":
                return campusOverview;
            case "forest":
                return forest;
            case "front_gate":
                return frontGate;
            case "hallway":
                return hallway;
            case "alchemy":
                return alchemy;
            default:
                return undefined;
        }
    }
}
