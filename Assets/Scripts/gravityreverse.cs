using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityreverse : MonoBehaviour
{
    private Rigidbody2D _rb;
    public bool rev = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) reverse();
    }

    void reverse()
    {
        _rb.gravityScale *= rev ? 1 : -1;
        transform.localScale = new Vector3(1, rev ? 1 : -1, 1);
        rev = !rev;
    }
}