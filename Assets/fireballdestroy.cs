using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballdestroy : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    
        void OnTriggerEnter2D()
		{
            Destroy (gameObject);
		}
    
}
