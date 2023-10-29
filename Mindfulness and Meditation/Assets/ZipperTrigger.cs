using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperTrigger : MonoBehaviour
{
	public AudioClip mySound;
	public bool isOpen = false;
	bool wordsSpawned = false;
	public GameObject[] objList = new GameObject[29];

	void Start()
    {

		
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
