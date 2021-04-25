using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Breaking : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private ChangingSprites _change;

    void Start()
    {
        _change = GetComponent<ChangingSprites>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other) //disables the colliders
    {
        if (other.CompareTag("Player") && PlayerMovement.action == PlayerMovement.Action.DASHING && Input.GetKey(KeyCode.Space))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/RocksBreaks");
            _boxCollider2D.enabled= false;
            DestroyImmediate(_boxCollider2D);
            _change.ChangeSprite();
        }
        
    }

}
