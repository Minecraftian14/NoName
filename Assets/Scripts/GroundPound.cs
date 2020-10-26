using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GroundPound : MonoBehaviour
{
    public float poundforce = 10f;
    private Rigidbody2D _rb;
    private CameraMovement _cameraMovement;
    private LayerMask _platformLayer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cameraMovement = Camera.main.GetComponent<CameraMovement>();
        _platformLayer = LayerMask.GetMask("Platform");
    }

    private float _buffer;
    private bool _isPound = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(Time.deltaTime * poundforce * Vector2.down);
            _buffer = _cameraMovement.modifier;
            _cameraMovement.modifier = 1;
            _isPound = true;
        }
        else if (_isPound && Physics2D.Raycast(_rb.position, Vector2.down, 2f, _platformLayer))
        {
            _cameraMovement.modifier = _buffer;
            _isPound = false;
        }
    }
}