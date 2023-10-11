using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GameObject.Find("Main Camera").transform.position;
        this.transform.position = new Vector3(pos.x, pos.y, pos.z+3);
        transform.Translate(0, 0, 2);
    }
}
