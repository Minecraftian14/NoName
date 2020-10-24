using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Dash : MonoBehaviour
{
    public float cooldown;
    public float dashForce;

    private float _lastDash = 0;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Time.time - _lastDash > cooldown))
        {
            _rb.AddForce(Math.Sign(_rb.velocity.x) * Time.deltaTime * dashForce * Vector2.right);
            _lastDash = Time.time;
        }
    }
}


/*
 *
 * if (Input.GetKey(KeyCode.LeftShift) && (Time.time - _lastDash > cooldown))
        {
            _hold = 100;
            _lastDash = Time.time;
        }

        if (_hold > 0)
        {
            _rb.position += new Vector2(Math.Sign(_rb.velocity.x) * Time.deltaTime * 1.4f, 0);
            _hold -= Time.deltaTime;
        }
 */