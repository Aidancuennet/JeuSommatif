using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  float speed;
    private Vector2 _direction;
    private Vector2 _targetPos;
    private Animator _animator;
    private const float DashRange = 2f;
    [SerializeField] GameObject dashEffect;
    
    private enum State
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    private State _stateDir = State.DOWN;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move() //Moves the player
    {
        transform.Translate(_direction * (speed * Time.deltaTime));
        if (_direction.x != 0 || _direction.y != 0)                          // PUT DEADZONE HERE
        {
              SetAnimatorMove(_direction);
        }
        else
        {
            _animator.SetLayerWeight(1,0);
        }
    }

    private void TakeInput() // Takes input to move the player
    {
        _direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _direction += Vector2.up;
          _stateDir = State.UP;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector2.down; 
            _stateDir = State.DOWN;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector2.left; 
            _stateDir = State.LEFT;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector2.right; 
            _stateDir = State.RIGHT;
        }
        

            if (Input.GetKeyDown(KeyCode.Space)) // Makes the player DASH
            {
                _targetPos = Vector2.zero;
                if (_stateDir == State.UP)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.y = 1;
                }

                if (_stateDir == State.DOWN)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.y = -1;
                }

                if (_stateDir == State.LEFT)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.x = -1;
                }

                if (_stateDir == State.RIGHT)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.x = 1;
                }

                if (_direction.x == 1 && _direction.y == 1)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.y = 1;
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.x = 1;
                }

                if (_direction.x == 1 && _direction.y == -1)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.y = -1;
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.x = 1;
                }

                if (_direction.x == -1 && _direction.y == 1)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.y = 1;
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.x = -1;
                }

                if (_direction.x == -1 && _direction.y == -1)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.y = -1;
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    _targetPos.x = -1;
                }

                transform.Translate(_targetPos * DashRange);
            }
        
    }

    private void SetAnimatorMove(Vector2 _direction)
    {
        _animator.SetLayerWeight(1,1);
        _animator.SetFloat("xDir", _direction.x);
        _animator.SetFloat("yDir", _direction.y);
    }
    
}
