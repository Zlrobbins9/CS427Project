using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    Light myLight;
    public GameObject anchor;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anchor.GetComponent<BadMessage>().breathingActive == true)
        {
            myLight.intensity = 0.5f;
        }
        else if(GameObject.Find("Bag").GetComponent<ZipperTrigger>().isOpen) //Bag
        {
            myLight.intensity = 0;
        }
        else
        {
            myLight.intensity = 0.5f;
        }
        
    }
}
