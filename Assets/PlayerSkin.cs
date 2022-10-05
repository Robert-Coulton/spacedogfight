using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    public SaveScriptableObject saveScriptableObject;

    public Sprite[] skins;
    public SpriteRenderer shipRenderer;
    void Start()
    {
        shipRenderer.sprite = skins[saveScriptableObject.skinIndex];
    }
}
