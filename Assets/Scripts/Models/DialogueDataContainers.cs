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

    // TODO: Rename to `dialogueFlowDataContainers`
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

public class DialogueContext
{
    public string format;
    public string dialogueTablePostfix;
    public Dictionary<string, DialogueFlowContainer> flowContainers;
    public Dictionary<string, DialogueDataContainer> dataContainers;
    public string entryDialogueID;

    public string TableName
    {
        get
        {
            switch (format)
            {
                case "2":
                return $"{DialogueContainerDefaults.FORMAT_V2_TABLE_PREFIX}{dialogueTablePostfix}";
                break;
                default:
                return $"{DialogueContainerDefaults.FALLBACK_TABLE_PREFIX}{dialogueTablePostfix}";
            }
            
        }
    }

    /**
     * Constructors & Initializers
     */
    public DialogueContext
    (
        string format,
        string dialogueTablePostfix,
        Dictionary<string, DialogueFlowContainer> flowContainers,
        Dictionary<string, DialogueDataContainer> dataContainers,
        string entryDialogueID
    )
    {
        format = format;
        dialogueTablePostfix = dialogueTablePostfix;
        flowContainers = flowContainers;
        dataContainers = dataContainers;
        entryDialogueID = entryDialogueID;
    }
    public DialogueContext(SerializableDialogueFlow container)
    {
        /*
        switch (container.format)
        {
            case "2":
                _useFormat2(container);
                break;
            case "3":
                // rewrited revision
                // _useFormat3(container);
                break;
            default:
                throw new ArgumentException("Unsupported format");
        }*/
        flowContainers = new Dictionary<string, DialogueFlowContainer>();
        dataContainers = new Dictionary<string, DialogueDataContainer>();
        _useFormat2(container);
    }

    private string prevDialogueID = "";
    private string nextDialogueID = "";
    private void _useFormat2(SerializableDialogueFlow container)
    {
        /**
         * Format 2 dialogue data are linear.
         */
        format = "2";
        dialogueTablePostfix = container.dialogueTablePostfix;
        entryDialogueID = container.dialogueFlow[0].dialogues[0].dialogueID;
        foreach (SerializableDialogueFlowDataContainer flow in container.dialogueFlow)
        {
            flowContainers.Add(flow.dialogueFlowID, new DialogueFlowContainer(flow));
            foreach (SerializableDialogueDataContainer dialogue in flow.dialogues)
            {
                // Instantiate current
                dataContainers.Add(dialogue.dialogueID, new DialogueDataContainer
                (
                    dialogue.dialogueID,
                    dialogue.l10nContentID,
                    dialogue.characterID,
                    flow.dialogueFlowID,
                    prevDialogueID,
                    nextDialogueID
                ));
                var _ = new DialogueDataContainer
                (
                    dialogue.dialogueID,
                    dialogue.l10nContentID,
                    dialogue.characterID,
                    flow.dialogueFlowID,
                    prevDialogueID,
                    nextDialogueID
                );

                // Update previous data to link with current
                if (prevDialogueID != "")
                {
                    dataContainers[prevDialogueID].nextDialogueID = dialogue.dialogueID;
                }
                prevDialogueID = dialogue.dialogueID;
            }
        }
    }

    /**
     * NOTE: Format 3 supports non-linear flow that images DialogueContext
     */
    private void _useFormat3() { throw new NotImplementedException(); }

    /**
     * Public Methods
     */
    public string GetContentText(DialogueDataContainer dialogueData)
    {
        return GetContentText(dialogueData.dialogueContentTextID);
    }
    public string GetContentText(string dialogueContentTextID)
    {
        return LS.__(TableName, dialogueContentTextID);
    }

    public string __(DialogueDataContainer d) => GetContentText(d);
    public string __(string k) => GetContentText(k);
}

public class DialogueFlowContainer
{
    public string flowID;
    public string backgroundID;

    public DialogueFlowContainer
    (
        string flowID,
        string backgroundID
    )
    {
        this.flowID = flowID;
        this.backgroundID = backgroundID;
    }
    public DialogueFlowContainer
    (
        SerializableDialogueFlowDataContainer container
    )
    {
        this.flowID = container.dialogueFlowID;
        this.backgroundID = container.backgroundID;
    }
}

[Serializable]
public class DialogueDataContainer
{
    public string dialogueID;

    /**
     * Dialogue Content
     */
    public string dialogueContentTextID;
    public string characterID;

    /**
     * Dialogue Flow
     */
    public string dialogueFlowID;
    public string prevDialogueID;
    public string nextDialogueID;

    public DialogueDataContainer
    (
        string dialogueID,
        string dialogueContentTextID,
        string characterID,
        string dialogueFlowID,
        string prevDialogueID,
        string nextDialogueID
    )
    {
        this.dialogueID = dialogueID;
        this.dialogueContentTextID = dialogueContentTextID;
        this.characterID = characterID;
        this.dialogueFlowID = dialogueFlowID;
        this.prevDialogueID = prevDialogueID;
        this.nextDialogueID = nextDialogueID;
    }
    public DialogueDataContainer
    (
        SerializableDialogueDataContainer container
    )
    {
        this.dialogueID = container.dialogueID;
        this.dialogueContentTextID = container.l10nContentID;
        this.characterID = container.characterID;
    }
}
