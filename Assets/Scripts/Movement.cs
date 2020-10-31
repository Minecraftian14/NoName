using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    public LayerMask platformLayer;

    public float jumpForce = 5f;
    public float movementSpeed = 5f;
    public float movementClamp = 50f;
    public Rigidbody2D _rb;
    public gravityreverse _gr;

    public Transform pr;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gr = GetComponent<gravityreverse>();
    }

    void FixedUpdate()
    {
        if (_rb.velocity.x != 0)
            pr.localRotation = Quaternion.Euler(0, _rb.velocity.x < 0 ? 180 : 0, 0);
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics2D.Raycast(_rb.position, Vector2.down, 2f, platformLayer))
                _rb.AddForce(Time.unscaledDeltaTime * jumpForce * Vector2.up);
            if (Physics2D.Raycast(_rb.position, Vector2.right, 1.5f, platformLayer))
                _rb.AddForce(Time.unscaledDeltaTime * jumpForce * new Vector2(-1, 1.5f));
            if (Physics2D.Raycast(_rb.position, Vector2.left, 1.5f, platformLayer))
                _rb.AddForce(Time.unscaledDeltaTime * jumpForce * new Vector2(1, 1.5f));
        }

        // for movement that does not suck
//        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
//        transform.position += movementSpeed * Time.deltaTime * movement;

        if (_rb.velocity.magnitude < movementClamp)
            _rb.AddForce(movementSpeed * Time.unscaledDeltaTime * Input.GetAxis("Horizontal") * Vector2.right);
    }
}