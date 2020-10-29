using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float stringLength = 10;

    private LayerMask _platformLayer;
    private Camera _cam;
    private LineRenderer _lineRenderer;
    private DistanceJoint2D _distanceJoint;
    private Rigidbody2D _rb;

    private void Start()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _distanceJoint.enabled = false;
        _platformLayer = LayerMask.GetMask("Platform");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

            if (Physics2D.Raycast(_rb.position, mousePos - _rb.position, Math.Min(stringLength,
                (_rb.position - mousePos).magnitude), _platformLayer))
            {
                _lineRenderer.SetPosition(0, mousePos);
                _lineRenderer.SetPosition(1, transform.position);

                _distanceJoint.connectedAnchor = mousePos;

                _distanceJoint.enabled = true;
                _lineRenderer.enabled = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }

        if (_distanceJoint.enabled) _lineRenderer.SetPosition(1, transform.position);
    }
}