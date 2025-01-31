using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoaderDebugger : MonoBehaviour
{
    public List<CharacterDefinition> characters;
    public List<Texture2D> characterTextures;
    public List<Sprite> characterSprites;

    [ContextMenu("Load Character Sprites")]
    public void LoadCharacterSprites()
    {
        characters = new List<CharacterDefinition>();
        characterTextures = new List<Texture2D>();
        characterSprites = new List<Sprite>();

        characters.Add(CharacterRegistry.Get("elina"));
        characters.Add(CharacterRegistry.Get("cecilia"));
        characters.Add(CharacterRegistry.Get("sophia"));
        characters.Add(CharacterRegistry.Get("coco"));

        foreach (CharacterDefinition character in characters)
        {
            Debug.Log($"Character ID: {character.characterID}");
            Debug.Log($"Character Display Name: {character.DisplayName}");
            Debug.Log($"Character Sprite Path: {character.spritePath}");
            characterSprites.Add(character.sprite);
            characterTextures.Add(character.texture);
            Debug.Log(Resources.Load<Sprite>(character.spritePath) == null ? "Sprite not found" : "Sprite found");
        }
    }
}