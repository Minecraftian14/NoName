using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletDirection : MonoBehaviour
{
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.rotation = Mathf.Atan(_rb.velocity.y / _rb.velocity.x) / Mathf.PI * 180;
        
//        transform.rotation = quaternion.Euler(0, 0, Mathf.Atan(-_rb.velocity.x / _rb.velocity.y) );
    }

    // For grenade
    // _rb.rotation = -_rb.velocity.x / _rb.velocity.y / Mathf.PI * 180;
}