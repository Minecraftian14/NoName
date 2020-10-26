using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Damage : MonoBehaviour
{
    public float spikesDamage = 10;

    private LayerMask _spikes;
    private PlayerData _data;
    private Rigidbody2D _rb;

    void Start()
    {
        
        _spikes = LayerMask.GetMask("Spikes");
        _data = GetComponent<PlayerData>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Physics2D.Raycast(_rb.position, Vector2.down, 2f, _spikes))
            _data.health -= spikesDamage;
    }
}