using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPlatform : MonoBehaviour
{
    string firstWordToCollide = "N/A";
    bool wordConnected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("platform2").GetComponent<CalendarPuzzleController>().HasLost())
        {
            firstWordToCollide = "N/A";
            wordConnected = false;
        }

        if (!firstWordToCollide.Equals("N/A"))
        {
            if (!wordConnected)
            {

                if (GameObject.Find(firstWordToCollide).GetComponent<GrabbableObject>().IsGrabbed() == false)
                {
                    GameObject.Find(firstWordToCollide).GetComponent<Transform>().position += new Vector3(0f, 0f, -0.3f);
                    GameObject.Find(firstWordToCollide).GetComponent<GrabbableObject>().enabled = false;
                    GameObject.Find(firstWordToCollide).GetComponent<Rigidbody>().isKinematic = true;
                    wordConnected = true; // the word is connected to the board
                }
                
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: move the 'paralyzed' word to the center of the plank
        if (firstWordToCollide == "N/A")
        {
            Debug.Log("First collision detected! It was with: " + collision.gameObject.name);
            firstWordToCollide = collision.gameObject.name;
        }
        
    }

    public string ReturnPhrase()
    {
        if (!wordConnected)
        {
            return "N/A";
        }
        else
        {
            return firstWordToCollide;
        }
        
    }
}
