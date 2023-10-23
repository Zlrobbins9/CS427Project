using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperTrigger : MonoBehaviour
{
	public AudioClip mySound;
	public bool isOpen = false;
	bool wordsSpawned = false;
    string[] stringList = { "Why is this so hard for you (1)", "Why is this so hard for you (2)", "Why is this so hard for you (3)", "Why is this so hard for you", 
		"you should be able to do this", "your classmates can do it, why cna't you_ (2)", "your classmates can do it, why cna't you_ (1)", "your classmates can do it, why cna't you_",
	"ycdt (4)", "ycdt (3)", "ycdt (2)", "ycdt (1)", "You'll never be able to focus, stop trying", "This is too much for you", "No one can help you, you're alone",
	"You just aren't trying hard enough", "You'll never be able to focus, stop trying (1)", "you should be able to do this (1)", "This is too much for you 1 (1)",
	"You'll never be able to focus, stop trying (2)", "you should be able to do this (2)", "This is too much for you 1 (2)", "No one can help you, you're alone (1)",
	"You'll never be able to focus, stop trying (3)", "You just aren't trying hard enough3 (1)", "You should be able to do this (3)", "This is too much for you 1 (3)",
	"Why is this so hard for you (4)", "This is too much for you 1 (4)"};

	GameObject[] objList = new GameObject[29];

	void Start()
    {
		Debug.Log(stringList.Length);
        for (int i = 0; i < 29; i++)
        {
			objList[i] = GameObject.Find(stringList[i]); //save all objects
		}

		
	}
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag =="Wand") //collision occured
		{
			GetComponent<AudioSource> ().PlayOneShot (mySound);
			isOpen = true;
		}
	}

	void Update()
    {
        if (isOpen && !wordsSpawned)
        {
            foreach (GameObject i in objList)
            {
				i.SetActive(true);
            }
			wordsSpawned = true;
        }
    }
}
