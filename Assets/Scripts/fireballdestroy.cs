using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballdestroy : MonoBehaviour
{
    
    
    void Start()
    {
        
    }

    
    
        void OnTriggerEnter2D(Collider2D hitInfo)
	{
            Destroy (gameObject);
        //tree burnable = hitInfo.GetComponent<tree>();
        //if (burnable != null)
        //{
        //    burnable.burn();
        //}
        burning b = hitInfo.GetComponent<burning>();
        if(b != null)
        Destroy(b.gameObject);
    }
  



}
