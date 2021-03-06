﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityreverse : MonoBehaviour
{
    private Rigidbody2D _rb;
    public bool rev = false;
    public Transform pr;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //pr = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) reverse();
    }

    void reverse()
    {
        _rb.gravityScale = rev ? 1 : -1;   
        pr.localScale = new Vector3(1, rev ? 1 : -1, 1);
        rev = !rev;
    }
}