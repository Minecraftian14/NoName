using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStarter : MonoBehaviour
{
    public float threshold = 10;

    private Rigidbody2D _rb;
    private ParticleSystem _ps;
    private BoxCollider2D _bc;

    private Transform _par;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ps = GetComponentInChildren<ParticleSystem>();
        _bc = GetComponent<BoxCollider2D>();

        _par = FindObjectOfType<Environment>().transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_rb.velocity.magnitude > threshold)
        {
            _ps.Play();
            _ps.transform.parent = _par;
//            _bc.isTrigger = false;
            Destroy(gameObject);
        }
    }
}