using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayer;

    public float jumpForce = 5f;
    public float movementSpeed = 5f;
    public float movementClamp = 50f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && Physics2D.Raycast(_rb.position, Vector2.down, 0.6f, platformLayer))
            _rb.AddForce(Time.deltaTime * jumpForce * Vector2.up);

        // for movement that does not suck
//        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
//        transform.position += movementSpeed * Time.deltaTime * movement;

        if (_rb.velocity.magnitude < movementClamp)
            _rb.AddForce(movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal") * Vector2.right);

    }
    
}