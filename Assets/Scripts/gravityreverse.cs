using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityreverse : MonoBehaviour
{
    private Rigidbody2D _rb;
    void Start()
	{
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            reverse();



        }
        
    }
    void reverse()
	{
        _rb.gravityScale *= -1;
        transform.Rotate (0, 0, 180f);
    }
}
