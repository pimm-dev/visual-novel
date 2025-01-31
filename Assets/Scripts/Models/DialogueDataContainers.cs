using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LS = LocalizationSupports;

/// TODO: Add limitation for clarify this code is only for
///       format version 2.

/**
 * based on `/Assets/StreamingAssets/*.json` files
 */

/**
 * Serializable data transfer objects for handling dialog data
 * All of DTO classes are started with `Serializable` prefix.
 */
[Serializable]
public class SerializableDialogueFlow
{
    public string dialogueTablePostfix;
    public List<SerializableDialogueFlowDataContainer> dialogueFlow;
    public SerializableDialogueFlow
    (
        string dialogueTablePostfix,
        List<SerializableDialogueFlowDataContainer> dialogueFlow
    )
    {
        this.dialogueTablePostfix = dialogueTablePostfix;
        this.dialogueFlow = dialogueFlow;
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        SerializableDialogueFlow other = (SerializableDialogueFlow)obj;
        return dialogueTablePostfix == other.dialogueTablePostfix
            && dialogueFlow.SequenceEqual(other.dialogueFlow);
    }
}

[Serializable]
public class SerializableDialogueFlowDataContainer {
    public string dialogueFlowID;
    public string backgroundID;
    public List<SerializableDialogueDataContainer> dialogues;
    public SerializableDialogueFlowDataContainer
    (
        string backgroundID,
        string dialogueFlowID,
        IEnumerable<SerializableDialogueDataContainer> dialogues
    )
    {
        this.backgroundID = backgroundID;
        this.dialogueFlowID = dialogueFlowID;
        this.dialogues = dialogues.ToList<SerializableDialogueDataContainer>();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        SerializableDialogueFlowDataContainer other = (SerializableDialogueFlowDataContainer)obj;
        return backgroundID == other.backgroundID
            && dialogueFlowID == other.dialogueFlowID
            && dialogues.SequenceEqual(other.dialogues);
    }
}

[Serializable]
public class SerializableDialogueDataContainer {
    public string dialogueID;
    public string characterID;
    public string l10nContentID;
    public SerializableDialogueDataContainer
    (
        string dialogueID,
        string characterID,
        string l10nContentID
    )
    {
        this.dialogueID = dialogueID;
        this.characterID = characterID;
        this.l10nContentID = l10nContentID;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        SerializableDialogueDataContainer other = (SerializableDialogueDataContainer)obj;
        return dialogueID == other.dialogueID
            && characterID == other.characterID
            && l10nContentID == other.l10nContentID;
    }
}

/**
 * DialogueDataContainers with control methods
 */

public class DialogueFlow
{
    public string dialogueTablePostfix;
    public List<DialogueFlowDataContainer> dialogueFlow;
    public DialogueFlow
    (
        string dialogueTablePostfix,
        IEnumerable<DialogueFlowDataContainer> dialogueFlow
    )
    {
        this.dialogueTablePostfix = dialogueTablePostfix;
        this.dialogueFlow = dialogueFlow.ToList<DialogueFlowDataContainer>();
    }

    public DialogueFlow
    (
        string dialogueTablePostfix,
        SerializableDialogueFlow container
    )
    {
        this.dialogueTablePostfix = container.dialogueTablePostfix;
        this.dialogueFlow = container.dialogueFlow.Select(
            d => new DialogueFlowDataContainer(dialogueTablePostfix, d)
        ).ToList();
    }

    public static explicit operator
    SerializableDialogueFlow(DialogueFlow container)
    {
        return new SerializableDialogueFlow(
            container.dialogueTablePostfix,
            container.dialogueFlow.Select(d => (SerializableDialogueFlowDataContainer)d).ToList()
        );
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        DialogueFlow other = (DialogueFlow)obj;
        return dialogueTablePostfix == other.dialogueTablePostfix
            && dialogueFlow.SequenceEqual(other.dialogueFlow);
    }
}

public class DialogueFlowDataContainer
{
    public string dialogueFlowID { get; }
    public string backgroundID { get; }
    public List<DialogueDataContainer> dialogues { get; }
    public BackgroundDefinition Background
    {
        get
        {
            return BackgroundRegistry.Get(backgroundID);
        }
    }

    public DialogueFlowDataContainer
    (
        string backgroundID,
        string dialogueFlowID,
        IEnumerable<DialogueDataContainer> dialogues
    )
    {
        this.backgroundID = backgroundID;
        this.dialogueFlowID = dialogueFlowID;
        this.dialogues = dialogues.ToList<DialogueDataContainer>();
    }

    public DialogueFlowDataContainer
    (
        string dialogueTableId,
        SerializableDialogueFlowDataContainer container
    )
    {
        this.backgroundID = container.backgroundID;
        this.dialogueFlowID = container.dialogueFlowID;
        this.dialogues = container.dialogues.Select(
            d => new DialogueDataContainer(dialogueTableId, d)
        ).ToList();
    }

    public static explicit operator
    SerializableDialogueFlowDataContainer(DialogueFlowDataContainer container)
    {
        return new SerializableDialogueFlowDataContainer(
            container.backgroundID,
            container.dialogueFlowID,
            container.dialogues.Select(d => (SerializableDialogueDataContainer)d)
        );
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        DialogueFlowDataContainer other = (DialogueFlowDataContainer)obj;
        return backgroundID == other.backgroundID
            && dialogueFlowID == other.dialogueFlowID
            && dialogues.SequenceEqual(other.dialogues);
    }
}

public class DialogueDataContainer
{
    private string dialogueTableID;  // for querying localized string
    public string dialogueID { get; }
    public string characterID { get; }
    public string l10nContentID { get; }
    public CharacterDefinition Character
    {
        get
        {
            return CharacterRegistry.Get(characterID);
        }
    }

    public string DialogueText
    {
        get
        {
            /**
             * TODO: Important performance issue here:
             * - All of DialogueDataContainer instances has same `dialogueTableID` value
             *   in the same DialogueFlowDataContainer instance.
             */
            return LS.__(dialogueTableID, l10nContentID);
        }
    }

    public DialogueDataContainer
    (
        string dialogueTablePostfix,
        string dialogueID,
        string characterID,
        string l10nContentID
    )
    {
        this.dialogueID = dialogueID;
        this.characterID = characterID;
        this.l10nContentID = l10nContentID;
        this.dialogueTableID = String.Format(LocalizationTableKeys.DIALOGUES_TABLE, dialogueTablePostfix);
    }

    public DialogueDataContainer
    (
        string dialogueTablePostfix,
        SerializableDialogueDataContainer container
    )
    {
        this.dialogueID = container.dialogueID;
        this.characterID = container.characterID;
        this.l10nContentID = container.l10nContentID;
        this.dialogueTableID = String.Format(LocalizationTableKeys.DIALOGUES_TABLE, dialogueTablePostfix);
    }

    public static explicit operator
    SerializableDialogueDataContainer(DialogueDataContainer container)
    {
        return new SerializableDialogueDataContainer(
            container.dialogueID,
            container.characterID,
            container.l10nContentID
        );
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        DialogueDataContainer other = (DialogueDataContainer)obj;
        return dialogueID == other.dialogueID
            && characterID == other.characterID
            && l10nContentID == other.l10nContentID
            && dialogueTableID == other.dialogueTableID;
    }
}
