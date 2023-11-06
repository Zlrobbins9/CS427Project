using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhaleExhale : MonoBehaviour
{

    public GameObject anchor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (anchor == null) //breathing exercise is over
        {
            Destroy(this.gameObject);
        }
    }
}
        


