using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMessage : MonoBehaviour
{
    public bool breathingActive = false;
    public int threshold = 20;
    GameObject wand;
    // Start is called before the first frame update
    void Start()
    {
        wand = GameObject.Find("Wand");
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 charPos = GameObject.Find("Main Camera").transform.position;
            if (charPos.z >= threshold)
            {
                breathingActive = true;
            }


            if (breathingActive)
            {

                if (Input.GetKey("c") || CAVE2.GetButtonDown(CAVE2.Button.ButtonLeft) || (wand.transform.eulerAngles.y > 50 && wand.transform.eulerAngles.y < 60))
                {
                    this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if (Input.GetKey("v") || CAVE2.GetButtonDown(CAVE2.Button.ButtonRight) || (wand.transform.eulerAngles.x > 50 && wand.transform.eulerAngles.x < 60))
                {
                    this.transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
                }

                if (this.transform.localScale.x < 0)
                {
                    Destroy(this.gameObject);
                }
            }
    }
}
