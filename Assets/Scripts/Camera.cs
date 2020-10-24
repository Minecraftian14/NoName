using System;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;

    public float modifier = 0.125f;
    public Vector3 offset;

    private void Start()
    {
//        offset = player.position - transform.position;
    }

    void FixedUpdate()
    {
//        transform.position = player.position + offset;

        float z = transform.position.z;
        Vector3 drag = Vector3.Lerp(transform.position, player.position + offset, modifier);
        drag.z = z;
        transform.position = drag;

    }
}