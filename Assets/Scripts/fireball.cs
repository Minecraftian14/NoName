using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{

    private Rigidbody2D _rb;
    public GameObject fired;
    public Transform firepoinnt;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(fired,firepoinnt.position,firepoinnt.rotation);
            
        }
    }
}