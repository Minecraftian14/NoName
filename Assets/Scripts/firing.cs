﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{
    public float fireballspeed = 20f;
    public Rigidbody2D fireballrb;
    
    void Start()
    {
        fireballrb.velocity = transform.right * fireballspeed;
        
    }

}
