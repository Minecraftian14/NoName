using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundpound : MonoBehaviour
{
    public float poundforce = 10f;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
		{
            _rb.AddForce(Vector2.down * poundforce * Time.deltaTime);
		}
    }
}
