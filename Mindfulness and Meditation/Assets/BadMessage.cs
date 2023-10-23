using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMessage : MonoBehaviour
{
    public bool breathingActive = false;
    public int threshold = 20;
    bool followPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        if (followPlayer)
        {
            Vector3 pos = GameObject.Find("Main Camera").transform.position;
            if (pos.z >= threshold || Input.GetKey("z"))
            {
                breathingActive = true;
            }

            this.transform.position = new Vector3(pos.x, pos.y, pos.z + 3);

            if (breathingActive)
            {

                if (Input.GetKey("c"))
                {

                    this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if (Input.GetKey("v"))
                {
                    this.transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
                }
            }
        }
        else if (GameObject.Find("Bag").GetComponent<ZipperTrigger>().isOpen)
        {
            followPlayer = true;
        }
    }
}
