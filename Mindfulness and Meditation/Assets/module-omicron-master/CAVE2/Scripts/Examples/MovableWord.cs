using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<GrabbableObject>().IsGrabbed())
        {
            Vector3 playerPos = GameObject.Find("Main Camera").transform.position;
            Vector3 dilf = new Vector3(playerPos.x-transform.position.x, playerPos.y - transform.position.y, playerPos.z - transform.position.z);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
                //Rigidbody.rotation = new Vector3(0,1,0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position.Set(transform.position.x+(dilf.x/10), transform.position.y + (dilf.y / 10), transform.position.z + (dilf.z / 10));
            }else if (Input.GetKey(KeyCode.UpArrow))
            {

            }
        }
    }
}
