﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFloor : MonoBehaviour
{
    string firstWordToCollide = "N/A";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("platform2").GetComponent<FloorPuzzleController>().HasLost())
        {
            firstWordToCollide = "N/A";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: move the 'paralyzed' word to the center of the plank
        if (firstWordToCollide == "N/A")
        {
            Debug.Log("First collision detected! It was with: " + collision.gameObject.name);
            firstWordToCollide = collision.gameObject.name;
            //TODO: take away the words' grabbable script
            GameObject.Find(firstWordToCollide).GetComponent<Transform>().position += new Vector3(0f,2f,0f);
            GameObject.Find(firstWordToCollide).GetComponent<GrabbableObject>().enabled = false;
            GameObject.Find(firstWordToCollide).GetComponent<Rigidbody>().isKinematic = true;
        }
        
    }

    public string ReturnPhrase()
    {
        return firstWordToCollide;
    }
}