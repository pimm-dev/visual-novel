using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class DialogueDataContainersTest
{
    private string postfix = "postfix";
    /**
     * Validate:
     * - Casting between normal containers and data transfer objects.
     * - Serialization of data transfer objects.
     * Expected: The serialized string should be same as the reference string.
     * 
     * NOTE: The reference value `_ref` have to generated manually.
     * If this test has been failed, please check the reference value.
     */
    /*
    [Test]
    public void ValidateMethodWorks_v2Serialization()
    {
        string _ref = "{\"dialogueTablePostfix\":\"postfix\",\"dialogueFlow\":[{\"dialogueFlowID\":\"dialogueFlowID_0\",\"backgroundID\":\"backgroundID_0\",\"dialogues\":[{\"dialogueID\":\"dialogueID_0_0\",\"characterID\":\"characterID_0_0\",\"l10nContentID\":\"l10nContentID_0_0\"},{\"dialogueID\":\"dialogueID_0_1\",\"characterID\":\"characterID_0_1\",\"l10nContentID\":\"l10nContentID_0_1\"},{\"dialogueID\":\"dialogueID_0_2\",\"characterID\":\"characterID_0_2\",\"l10nContentID\":\"l10nContentID_0_2\"}]},{\"dialogueFlowID\":\"dialogueFlowID_1\",\"backgroundID\":\"backgroundID_1\",\"dialogues\":[{\"dialogueID\":\"dialogueID_1_0\",\"characterID\":\"characterID_1_0\",\"l10nContentID\":\"l10nContentID_1_0\"},{\"dialogueID\":\"dialogueID_1_1\",\"characterID\":\"characterID_1_1\",\"l10nContentID\":\"l10nContentID_1_1\"},{\"dialogueID\":\"dialogueID_1_2\",\"characterID\":\"characterID_1_2\",\"l10nContentID\":\"l10nContentID_1_2\"}]}]}";

        DialogueFlow dialogueFlow = new DialogueFlow
        (
            postfix,
            (
                from i in Enumerable.Range(0, 2)
                select new DialogueFlowDataContainer
                (
                    $"backgroundID_{i}",
                    $"dialogueFlowID_{i}",
                    (
                        from j in Enumerable.Range(0, 3)
                        select new DialogueDataContainer
                        (
                            postfix,
                            $"dialogueID_{i}_{j}",
                            $"characterID_{i}_{j}",
                            $"l10nContentID_{i}_{j}"
                        )
                    ).ToList<DialogueDataContainer>()
                )
            ).ToList<DialogueFlowDataContainer>()
        );
        SerializableDialogueFlow serializableDialogueFlow = (SerializableDialogueFlow)dialogueFlow;
        Assert.AreEqual(_ref, JsonUtility.ToJson(serializableDialogueFlow));
    }

    [Test]
    public void ValidateMethodWorks_v2Deserialization()
    {
        DialogueFlow dialogueFlow = new DialogueFlow
        (
            postfix,
            (
                from i in Enumerable.Range(0, 2)
                select new DialogueFlowDataContainer
                (
                    $"backgroundID_{i}",
                    $"dialogueFlowID_{i}",
                    (
                        from j in Enumerable.Range(0, 3)
                        select new DialogueDataContainer
                        (
                            postfix,
                            $"dialogueID_{i}_{j}",
                            $"characterID_{i}_{j}",
                            $"l10nContentID_{i}_{j}"
                        )
                    ).ToList<DialogueDataContainer>()
                )
            ).ToList<DialogueFlowDataContainer>()
        );

        SerializableDialogueFlow serializableFlow = (SerializableDialogueFlow)dialogueFlow;
        SerializableDialogueFlow deserializedSerializable = JsonUtility.FromJson<SerializableDialogueFlow>(JsonUtility.ToJson(serializableFlow));

        // The `Equals` method should be implemented in `SerializableDialogueFlow`.
        Assert.IsTrue(deserializedSerializable.Equals(serializableFlow));
        Assert.AreEqual(serializableFlow, deserializedSerializable);

        DialogueFlow deserialized = new DialogueFlow(deserializedSerializable);
        Assert.AreEqual(dialogueFlow, deserialized);
    }

    [Test]
    public void ValidateMethodWorks_DeserializationFromFile()
    {
        try
        {
            // Try to load v1 formatted chapter 1 file.
            DialogueLoader.LoadDialogueFlow("1", "1");
        }
        catch (DeprecatedApiException)
        {
            goto v1ExpectedExceptionRaised;
        }
        Assert.Fail("Format v1 handler: No exception raised.");

        v1ExpectedExceptionRaised:
        // Try to load v2 formatted chapter 1 file.
        SerializableDialogueFlow deserialized = DialogueLoader.LoadDialogueFlow("1", "2") as SerializableDialogueFlow;
    }*/
}
