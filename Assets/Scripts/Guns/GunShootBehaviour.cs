using System;
using System.Collections;
using System.Collections.Generic;
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

        _gun = new Revolver(bullet);
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector3 mv = _camera.ScreenToWorldPoint(Input.mousePosition);
        mv.z = transform.position.z;
        Vector2 vector = mv;
        _gunPos.position = _rb.position + (vector - _rb.position).normalized;
        _gunPos.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.right, _gunPos.localPosition));
        
        if (Input.GetKey(KeyCode.LeftAlt))
            _gun.Shoot(_rb.position, _gunPos.localPosition.normalized);
    }
}