using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GunShootBehaviour : MonoBehaviour
{
    public GameObject bullet;

    private Transform _gunPos;
    private Rigidbody2D _rb;
    private GunModel _gun;
    private Camera _camera;

    private void Start()
    {
        foreach (var comp in GetComponentsInChildren<Transform>())
            if (comp.name.Equals("Gun"))
                _gunPos = comp;
        _gunPos.position = transform.position + transform.up;
        _rb = GetComponent<Rigidbody2D>();

        _gun = new Shotgun(bullet, this);
        _camera = Camera.main;
    }

    private int _rotationFactorY;

    private void Update()
    {
        _rotationFactorY = Math.Sign(_gunPos.localPosition.x);

        _gunPos.localScale = new Vector3(0.5f, 0.5f * (_rotationFactorY == 0 ? 1 : _rotationFactorY), 1);

        _gun.Update();
    }

    private void FixedUpdate()
    {
        Vector3 mv = _camera.ScreenToWorldPoint(Input.mousePosition);
        mv.z = transform.position.z;
        Vector2 vector = mv;

        _gunPos.position = _rb.position + (vector - _rb.position).normalized;
        _gunPos.rotation = Quaternion.Euler(0, 0,
            (transform.localScale.y) * 180 / Mathf.PI *
            Mathf.Atan2(_gunPos.localPosition.y, _gunPos.localPosition.x));

        if (Input.GetKey(KeyCode.LeftAlt))
            _gun.Shoot(_rb.position, _gunPos.localPosition.normalized);
    }
}