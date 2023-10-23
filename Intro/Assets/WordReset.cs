using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordReset : MonoBehaviour
{
    Vector3 startPos, startRot;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        Debug.Log("Im disabled!");
        GetComponent<GrabbableObject>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.position = startPos;
        gameObject.transform.eulerAngles = startRot;
    }

    private void OnEnable()
    {
        Debug.Log("Im enabled!");
        
        
    }
}
