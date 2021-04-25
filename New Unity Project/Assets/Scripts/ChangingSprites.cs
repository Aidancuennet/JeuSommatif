using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSprites : MonoBehaviour
{
    [SerializeField] Sprite sprite1; // Drag your first sprite here
    [SerializeField] Sprite sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer; 

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1
    }
    

    public void ChangeSprite ()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = sprite2;
            DestroyImmediate(sprite1);
        }
    }
}
