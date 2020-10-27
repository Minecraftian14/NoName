using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public int fallSpeed = 2000;
    public int elevator = 400;
    public float poundforce = 10f;

    private Rigidbody2D _rb;
    private CameraMovement _cameraMovement;
    private LayerMask _platformLayer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cameraMovement = Camera.main.GetComponent<CameraMovement>();
        _platformLayer = LayerMask.GetMask("Platform");
    }

    private float _buffer;
    private bool _isPound = false;

    void FixedUpdate()
    {
        if (_rb.velocity.y < 0)
        {
            if (!_isPound && Input.GetKeyDown(KeyCode.S))
            {
                _rb.AddForce(Time.deltaTime * fallSpeed * elevator * Vector2.down);
                _buffer = _cameraMovement.modifier;
                _cameraMovement.modifier = 1;
                _isPound = true;
            }
            else
                _rb.AddForce(Time.deltaTime * fallSpeed * Vector2.down);
        }

        
        if (_isPound && Physics2D.Raycast(_rb.position, Vector2.down, 2f, _platformLayer))
        {
            _cameraMovement.modifier = _buffer;
            _isPound = false;
        }
    }
}