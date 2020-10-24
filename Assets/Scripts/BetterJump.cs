using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public int fallSpeed = 2000;
    public int elevator = 400;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            if (Input.GetKeyDown(KeyCode.S))
                rb.AddForce(Time.deltaTime * fallSpeed * elevator * Vector2.down);
            else
                rb.AddForce(Time.deltaTime * fallSpeed * Vector2.down);
        }
    }
}