using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueControllers.Options;

[System.Serializable]
public class DialogueControllerDescriptor
{
    public bool enabled;
    public string currentChapter;
    public string currentDialogueFlowID;
    public string currentDialogueID;

    public DialogueControllerDescriptor()
    {
        // Refer: Assets/Scripts/Definitions/DialogueControllerDefaults.cs
        enabled = DialogueControllerDescriptorDefaults.ENABLED;
        currentDialogueFlowID = DialogueControllerDescriptorDefaults.CURRENT_DIALOGUE_FLOW_ID;
        currentDialogueID = DialogueControllerDescriptorDefaults.CURRENT_DIALOGUE_ID;
        currentChapter = DialogueControllerDescriptorDefaults.CURRENT_CHAPTER;
    }

    public DialogueControllerDescriptor(bool enabled, string currentChapter, string currentDialogueID)
    {
        enabled = enabled;
        currentChapter = currentChapter;
        currentDialogueFlowID = currentDialogueFlowID;
        currentDialogueID = currentDialogueID;
    }
}

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private DialogueContext context;

    // descriptors
    [SerializeField]
    private DialogueControllerDescriptor descriptor = new DialogueControllerDescriptor();
    [SerializeField]
    private DialogueControllerDescriptor fDescriptor;  // serialized

    // options
    [SerializeField]
    private DialogueControllerOptions options;

    // for enumerators
    private IEnumerator playContextEnumerator;
    [SerializeField] private DialogueDataContainer currentDialogue;
    [SerializeField] private string targetDisplayContent;  // Optimizing: l10n processed
    [SerializeField] private string currentDisplayingContent;

    // player-game interaction flags
    [SerializeField] private bool skipWrittingRequested = false;
    [SerializeField] private bool isAutoWritting = false;

    /**
     * Initializers
     */
    [ContextMenu("Awake()")]
    private void Awake()
    {
        LoadRequiredResources();
        LoadDialogueContext();
    }
    private void LoadRequiredResources()
    {
        /**
         * Load required resources here.
         *
         * ACTION REQUIRED: When instantiating this object, frame drop can be expected.
         * To avoid this, other loading strategies are required (e.g. lazy loading,
         * async(This method is required to ensure that resource is always loaded.)).
         */
        Sprite _;  // To avoid CS0201
        foreach(BackgroundDefinition each in BackgroundRegistry.all)
        {
            _ = each.sprite;
        }
        foreach(CharacterDefinition each in CharacterRegistry.all)
        {
            _ = each.sprite;
        }
    }

    private void LoadDialogueContext()
    {
        context = new DialogueContext
        (
            DialogueLoader.LoadDialogueFlow<SerializableDialogueFlow>
            (
                descriptor.currentChapter ?? DialogueControllerDescriptorDefaults.CURRENT_CHAPTER
            )
        );
        if (descriptor.currentDialogueID == null || descriptor.currentDialogueID == "")
        {
            descriptor.currentDialogueID = context.entryDialogueID;
        }
        _dialogueSetNext();
    }

    [ContextMenu("Start()")]
    private void Start()
    {
        playContextEnumerator = PlayDialogueContext();
        StartCoroutine(playContextEnumerator);
    }

    [ContextMenu("Update()")]
    private void Update()
    {
        _validateAndSyncFields();
    }

    [ContextMenu("OnClick()")]
    public void OnClick()
    {
        if (descriptor.enabled)
        {
            skipWrittingRequested = true;
        }
        else
        {
            descriptor.enabled = true;
        }
    }

    private void _validateAndSyncFields()
    {
        // auto writting
        if (isAutoWritting)
        {
            if (options.eachDialogueEndsAction != EachDialogueEndsAction.Continue)
            {
                options.eachDialogueEndsAction = EachDialogueEndsAction.Continue;
                descriptor.enabled = true;
            }
        }
        else
        {
            if (options.eachDialogueEndsAction != EachDialogueEndsAction.Suspend)
            {
                options.eachDialogueEndsAction = EachDialogueEndsAction.Suspend;
            }
        }

        // 
    }

    private void _dialogueSetNext()
    {
        currentDialogue = context.dataContainers[descriptor.currentDialogueID];
        targetDisplayContent = context.__(currentDialogue);
        currentDisplayingContent = "";
    }

    private IEnumerator PlayDialogueContext()
    {
        /**
         * Depends on descriptor.currentDialogueID. Initializing required.
         * In this code, there is LoadDialogueContext() that initializes the context.
         *
         * NOTICE: There are not validation checks for the descriptor.currentDialogueID.
         *         If the value is invalid, the program will occurs standard exceptions.
         */
        int i;  // for avoiding overhead: used for forloop in writting dialogue content
        while (true)
        {
            if (!descriptor.enabled)
            {
                yield return new WaitUntil(() => descriptor.enabled);
                continue;
            }

            
            i = 0;
            while (currentDisplayingContent != targetDisplayContent)
            {
                if (skipWrittingRequested)
                {
                    skipWrittingRequested = false;

                    // Autoplay would be stopped when writting is skipped.
                    _setWrittingStop();
                    currentDisplayingContent = targetDisplayContent;
                    break;
                }

                currentDisplayingContent += targetDisplayContent[i++];
                yield return new WaitForSeconds(options.writtingCharacterInterval);
            }
            // ends each dialogue
            switch (options.eachDialogueEndsAction)
            {
                case EachDialogueEndsAction.Suspend:
                    descriptor.enabled = false;
                    yield return new WaitUntil(() => descriptor.enabled);
                    break;
                case EachDialogueEndsAction.Continue:
                    break;
            }
            yield return new WaitUntilOrForSeconds
            (
                // Condition: When skipWrittingRequested during waiting for next dialogue
                () =>
                {
                    if (skipWrittingRequested)
                    {
                        skipWrittingRequested = false;
                        return true;
                    }
                    return false;
                },
                // Wait Until
                options.startNextDialogueDelayWhenAutoWritting
            );
            descriptor.currentDialogueID = currentDialogue.nextDialogueID;
            _dialogueSetNext();
        }
    }

    private void _setWrittingStop()
    {
        options.eachDialogueEndsAction = EachDialogueEndsAction.Suspend;
        descriptor.enabled = false;
        isAutoWritting = false;
    }
}
