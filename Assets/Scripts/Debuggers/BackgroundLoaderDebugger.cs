using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoaderDebugger : MonoBehaviour
{
    public List<BackgroundDefinition> backgrounds;
    public List<Texture2D> backgroundTextures;
    public List<Sprite> backgroundSprites;

    [ContextMenu("Load Background Sprites")]
    public void LoadBackgroundSprites()
    {
        backgrounds = new List<BackgroundDefinition>();
        backgroundTextures = new List<Texture2D>();
        backgroundSprites = new List<Sprite>();

        backgrounds.Add(BackgroundRegistry.Get("black"));
        backgrounds.Add(BackgroundRegistry.Get("hall"));
        backgrounds.Add(BackgroundRegistry.Get("bedroom"));
        backgrounds.Add(BackgroundRegistry.Get("classroom"));
        backgrounds.Add(BackgroundRegistry.Get("testroom"));
        backgrounds.Add(BackgroundRegistry.Get("campus_overview"));
        backgrounds.Add(BackgroundRegistry.Get("forest"));
        backgrounds.Add(BackgroundRegistry.Get("front_gate"));
        backgrounds.Add(BackgroundRegistry.Get("hallway"));
        backgrounds.Add(BackgroundRegistry.Get("alchemy"));
        backgrounds.Add(BackgroundRegistry.Get("empty"));
        backgrounds.Add(BackgroundRegistry.Get("GET_FALLBACK"));

        foreach (BackgroundDefinition background in backgrounds)
        {
            Debug.Log($"Background ID: {background.backgroundID}");
            Debug.Log($"Background Sprite Path: {background.spritePath}");
            backgroundSprites.Add(background.sprite);
            backgroundTextures.Add(background.texture);
            Debug.Log(Resources.Load<Sprite>(background.spritePath) == null ? "Sprite not found" : "Sprite found");
        }
    }
}