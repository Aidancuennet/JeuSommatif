using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  float speed;
    [SerializeField] private Animator _animator;
    private Vector2 _direction;
    private Vector2 _targetPos;
    private const float DashRange = 1.4f;
    public Animator Animator { get; private set; }
    private enum Facing
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    private Facing _facingDir = Facing.DOWN;
    private static float x;
    private static float y;
    private static float sqrMagnitude;

    

    void Start()
    {

    }
    void Update()
    {
        PlayerMovement.x = Input.GetAxisRaw("Horizontal");
        PlayerMovement.y = Input.GetAxisRaw("Vertical");
        Animator.SetFloat("Horizontal", PlayerMovement.x);
        Animator.SetFloat("Vertical", PlayerMovement.y);
        Animator.SetFloat("Speed", PlayerMovement.sqrMagnitude);
        TakeInput();
            Move();
    }

    private void Move() //Moves the player
    {
        transform.Translate(_direction * (speed * Time.deltaTime));
        if (_direction.x != 0 || _direction.y != 0)                          // PUT DEADZONE HERE
        {
            
            
        }
        else
        {
            
        }
    }

    private void TakeInput() // Takes input to move the player
    {
        _direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
          _direction += Vector2.up;
          _facingDir = Facing.UP;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector2.down; 
            _facingDir = Facing.DOWN;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector2.left; 
            _facingDir = Facing.LEFT;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector2.right; 
            _facingDir = Facing.RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Makes the player DASH
        {

            _targetPos = Vector2.zero;
            if (_facingDir == Facing.UP)
            {
                _targetPos.y = 1;
            }
            if (_facingDir == Facing.DOWN)
            {
                _targetPos.y = -1;
            }
            if (_facingDir == Facing.LEFT)
            {
                _targetPos.x = -1;
            }
            if (_facingDir == Facing.RIGHT)
            {
                _targetPos.x = 1;
            }
            transform.Translate(_targetPos* DashRange);
        }
    }

    
}