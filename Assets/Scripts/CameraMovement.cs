using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public float modifier = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
//        transform.position = player.position + offset;

        float z = transform.position.z;
        Vector3 drag = Vector3.Lerp(transform.position, player.position + offset, modifier);
        drag.z = z;
        transform.position = drag;
    }
}