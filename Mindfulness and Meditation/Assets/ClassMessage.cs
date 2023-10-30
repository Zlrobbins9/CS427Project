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
        Vector3 relativePos = GameObject.Find("Main Camera").transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;

        if (!doneOnce)
        {
            doneOnce = true;
            this.gameObject.SetActive(false);
        }
    }
}
