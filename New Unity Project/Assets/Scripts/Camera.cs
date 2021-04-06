using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing;
    [SerializeField] Vector3 offset;
    private Animator _camAnimator;

    void Start()
    {
        _camAnimator = GetComponent<Animator>();
    }
    void FixedUpdate() // Camera that follows the player
    {
        if (player != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            transform.position = newPosition;

        }

        if (Input.GetKeyDown(KeyCode.Space)) // Makes the player DASH
        {
            _camAnimator.SetTrigger("shake");
        }

    }
    
}
