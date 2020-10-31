using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;

    private ParticleSystem _particles;
    private SpriteRenderer _renderer;

    private bool _update = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _particles = gameObject.GetComponentInChildren<ParticleSystem>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(!_update) return;
        rb.rotation = Mathf.Atan(rb.velocity.y / rb.velocity.x) / Mathf.PI * 180;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            _update = false;
            rb.rotation = 0;
            rb.velocity = Vector2.zero;
            
            _particles.Play();
            
            Destroy(gameObject, _particles.main.duration);
            Destroy(_renderer);
            
        }
    }

    // For grenade
    // _rb.rotation = -_rb.velocity.x / _rb.velocity.y / Mathf.PI * 180;
}