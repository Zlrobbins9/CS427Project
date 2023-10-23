using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ycdt (3)").GetComponent<BadMessage>().breathingActive == true)
        {
            myLight.intensity = 0.5f;
        }
        else
        {
            myLight.intensity = 0;
        }
        
    }
}
