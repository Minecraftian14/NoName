using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDon : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("spike")) Debug.Log("u ded");
    }

}