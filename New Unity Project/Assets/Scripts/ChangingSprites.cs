using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSprites : MonoBehaviour
{
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2; 

    private SpriteRenderer _spriteRenderer; 

    void Start ()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer.sprite == null) // if no sprite, use first sprite
            _spriteRenderer.sprite = sprite1; 
    }
    

    public void ChangeSprite ()
    {
        if (_spriteRenderer.sprite == sprite1) // if there is sprite 1 then go for sprite 2
        {
            _spriteRenderer.sprite = sprite2;
        }
    }
}
