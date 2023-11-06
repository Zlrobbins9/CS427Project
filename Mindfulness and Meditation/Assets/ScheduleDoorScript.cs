using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleDoorScript : MonoBehaviour
{

    public GameObject anchor;
    bool disabledOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anchor == null && !disabledOnce) //breathing exercise is over
        {
            disabledOnce = true;
            this.gameObject.SetActive(false);
        }
    }
}
