using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMessage : MonoBehaviour
{
    bool doneOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!doneOnce)
        {
            doneOnce = true;
            this.gameObject.SetActive(false);
        }
    }
}
