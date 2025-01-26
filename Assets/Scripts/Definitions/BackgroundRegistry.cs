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
    public static BackgroundDefinition black = new BackgroundDefinition("black", "Sprites/Backgrounds/Black");
    public static BackgroundDefinition hall = new BackgroundDefinition("hall", "Sprites/Backgrounds/Hall");
    public static BackgroundDefinition bedroom = new BackgroundDefinition("bedroom", "Sprites/Backgrounds/Bedroom");
    public static BackgroundDefinition classroom = new BackgroundDefinition("classroom", "Sprites/Backgrounds/Classroom");
    public static BackgroundDefinition classroomTesting = new BackgroundDefinition("classroom_testing", "Sprites/Backgrounds/ClassroomTesting");
    public static BackgroundDefinition campusOverview = new BackgroundDefinition("campus_overview", "Sprites/Backgrounds/CampusOverview");
    public static BackgroundDefinition forest = new BackgroundDefinition("forest", "Sprites/Backgrounds/Forest");
    public static BackgroundDefinition frontGate = new BackgroundDefinition("front_gate", "Sprites/Backgrounds/FrontGate");
    public static BackgroundDefinition hallway = new BackgroundDefinition("hallway", "Sprites/Backgrounds/Hallway");
    // TODO: Rename to "alchemyLab"
    public static BackgroundDefinition alchemy = new BackgroundDefinition("alchemy", "Sprites/Backgrounds/Alchemy");

    /**
     * Aliases
     */
    public static BackgroundDefinition undefined = black;

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
            case "classroom_testing":
                return classroomTesting;
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
