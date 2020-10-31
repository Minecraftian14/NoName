using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAWARUDO : MonoBehaviour
{
    private float timespeed = 0.5f;
    private float lastTimestop = 0;
    public float Timestopcooldown;
    public float timestopduration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastTimestop > Timestopcooldown)
        {
            Time.timeScale = timespeed;
            Time.timeScale += (1f / timestopduration) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 5);
            lastTimestop = Time.time;
        }
    }
}
