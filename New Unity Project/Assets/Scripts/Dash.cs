using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float dashSpeed;
    private float _dashTime;
    [SerializeField] float startDashTime;
    private int _direction;
    public GameObject dashEffect;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _dashTime = startDashTime;
    }

    void Update()
    {
        if (_direction == 0)
        {
            if ( Input.GetKeyDown(KeyCode.A))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                _direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                _direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                _direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                _direction = 4;
            }
          
        }

        if (_dashTime <= 0)
        {
            _direction = 0;
            _dashTime = startDashTime;
            _rb.velocity = Vector2.zero;
        }
        else
        {
            _dashTime -= Time.deltaTime;
            if (_direction == 1)
            {
                _rb.velocity = Vector2.left * dashSpeed;
            } else if (_direction == 2)
            {
                _rb.velocity = Vector2.right * dashSpeed;
            } else if (_direction == 3)
            {
                _rb.velocity = Vector2.up * dashSpeed;
            } else if (_direction == 4)
            {
                _rb.velocity = Vector2.down * dashSpeed;
            }
        }
    }
}
