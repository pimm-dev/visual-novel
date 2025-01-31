using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Localization;
using LS = LocalizationSupports;

/**
 * This test refers not only `CharacterDefinition` but also `CharacterRegistry`.
 */
public class CharactersTest
{
    // Tests in this class use LocalizationTable must use CharacterTable
    private const string _T = LocalizationTableKeys.CHARACTERS_TABLE;
    private CharacterDefinition sample = CharacterRegistry.elina;

    /**
     * Validate `CharacterDefinition`'s `DisplayName` property.
     * Expected: `DisplayName` should return the localized string.
     * NOTICE: The reference value of this test will be set manually.
     * If this test has been failed, please check the reference value.
     */
    [Test]
    public void ValidatePropertyWorks_CharacterDefinition_DisplayName_Manual()
    {
        // If this test has been failed, check these `referenceValue*` value.
        string referenceValueEN = "Elina";
        string referenceValueKR = "엘리나";

        LS.SetLocale(LocalizationRegistry.en);
        Assert.AreEqual(referenceValueEN, LS.__(_T, sample.displayI18nID));

        LS.SetLocale(LocalizationRegistry.ko);
        Assert.AreEqual(referenceValueKR, LS.__(_T, sample.displayI18nID));
    }

    /**
     * Validate `CharacterDefinition`'s `DisplayName` property.
     * Expected: `DisplayName` should return the localized string.
     */
    [Test]
    public void ValidatePropertyWorks_CharacterDefinition_DisplayName_Dynamic()
    {
        LocalizedString stringRef = new LocalizedString() { TableReference = _T, TableEntryReference = sample.displayI18nID };
        string queried = stringRef.GetLocalizedString();

        // NOTICE: Because latest implementation of `LS.__` is same as #1, the results should be equal.
        Assert.AreEqual(queried, sample.DisplayName);
    }

    /**
     * Validate all of character data are registered in `CharacterRegistry`.
     * NOTICE: The reference value of this test will be set manually.
     * If this test has been failed, please check the reference value.
     */
    [Test]
    public void ValidateAllRegistered_CharacterRegistry_DisplayName_Manual()
    {
        LS.SetLocale(LocalizationRegistry.en);
        Assert.AreEqual("Elina", CharacterRegistry.elina.DisplayName);
        Assert.AreEqual("Cecilia", CharacterRegistry.cecilia.DisplayName);
        Assert.AreEqual("Sophia", CharacterRegistry.sophia.DisplayName);
        Assert.AreEqual("Coco", CharacterRegistry.coco.DisplayName);
        Assert.AreEqual("!!__WARN: UNDEFINED CHARACTER__!!", CharacterRegistry.undefined.DisplayName);
    }

    /**
     * Validate all of character textures are loaded correctly.
     */
    [Test]
    public void ValidateAllTexturesLoaded()
    {
        Assert.IsNotNull(CharacterRegistry.Get("elina").texture);
        Assert.IsNotNull(CharacterRegistry.Get("cecilia").texture);
        Assert.IsNotNull(CharacterRegistry.Get("sophia").texture);
        Assert.IsNotNull(CharacterRegistry.Get("coco").texture);
    }
}
