using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMessage : MonoBehaviour
{
    public bool breathingActive = false;
    public int threshold = 20;
    string breathState = "none";
    string lastState = "none";
    public GameObject inhaleWord, exhaleWord;

    GameObject wand;
    // Start is called before the first frame update
    void Start()
    {
        wand = GameObject.Find("Wand");
    }

    // Update is called once per frame
    void Update()
    {

        float a = 2.25f;        
        Vector3 charPos = GameObject.Find("Main Camera").transform.position;
        if (charPos.z >= threshold)
        {
            breathingActive = true;
            inhaleWord.SetActive(true);
            exhaleWord.SetActive(false);
        }

        if (breathingActive)
        {
            lastState = breathState;

            if (Input.GetKey("c") || CAVE2.GetButtonDown(CAVE2.Button.ButtonLeft) /*|| (wand.transform.eulerAngles.y > 50 && wand.transform.eulerAngles.y < 60)*/)
            {
                breathState = "in";
            }
            else if (Input.GetKey("v") || CAVE2.GetButtonDown(CAVE2.Button.ButtonRight) /*|| (wand.transform.eulerAngles.x > 50 && wand.transform.eulerAngles.x < 60)*/)
            {
                breathState = "out";
            }
            else
            {
                breathState = "none";
            }

            if (breathState.Equals("in"))
            {
                this.transform.localScale += new Vector3(-0.04f*a, -0.04f * a, -0.04f * a);
                inhaleWord.SetActive(true);
                exhaleWord.SetActive(false);
            }
            else if (breathState.Equals("out"))
            {
                this.transform.localScale += new Vector3(-0.05f * a, -0.05f * a, -0.05f * a);
                inhaleWord.SetActive(false);
                exhaleWord.SetActive(true);
            }
            else
            {
                inhaleWord.SetActive(true);
                exhaleWord.SetActive(true);
            }

            if (!lastState.Equals("in") && breathState.Equals("in")) //new breath has started
            {
                Debug.Log("Growing!");
                this.transform.localScale += new Vector3(10.0f, 10.0f, 1.0f);
            }

            Debug.Log("breathstate is " + breathState + ", laststate is " + lastState);

            if (this.transform.localScale.x < 0)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
