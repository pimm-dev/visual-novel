using System.Collections;
using System.Collections.Generic;
using System.Linq;

/**
 * based on `/Assets/StreamingAssets/*.json` files
 */

public class DialogueFlowDataContainer {
    public string backgroundID { get; }
    public string dialogueFlowID { get; }
    public List<DialogueDataContainer> dialogues { get; }
    public BackgroundDefinition Background
    {
        get
        {
            return BackgroundRegistry.Get(backgroundID);
        }
    }

    public DialogueFlowDataContainer(
        string backgroundID,
        string dialogueFlowID,
        IEnumerable<DialogueDataContainer> dialogues
    )
    {
        this.backgroundID = backgroundID;
        this.dialogueFlowID = dialogueFlowID;
        this.dialogues = dialogues.ToList<DialogueDataContainer>();
    }
}
public class DialogueDataContainer {
    public string dialogueID { get; }
    public string characterID { get; }
    public string dialogueTextI18nID { get; }
    public CharacterDefinition Character
    {
        get
        {
            return CharacterRegistry.Get(characterID);
        }
    }

    public DialogueDataContainer(
        string dialogueID,
        string characterID,
        string dialogueTextI18nID
    )
    {
        this.dialogueID = dialogueID;
        this.characterID = characterID;
        this.dialogueTextI18nID = dialogueTextI18nID;
    }
}
