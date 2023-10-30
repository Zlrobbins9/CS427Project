using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperTrigger : MonoBehaviour
{
	public AudioClip mySound;
	public bool isOpen = false;
	bool meanWordsSpawned = false;
	bool niceWordsSpawned = false;
	public GameObject[] meanWordList;
	public GameObject[] niceWordList;

	void Start()
    {

		
	}
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag =="Wand" && !isOpen) //collision occured
		{
			GetComponent<AudioSource> ().PlayOneShot (mySound);
			isOpen = true;
		}
	}

	void Update()
    {
        if (isOpen && !meanWordsSpawned)
        {
			Debug.Log("spawning mean words...");
			foreach (GameObject i in meanWordList)
            {
				i.SetActive(true);
            }
			meanWordsSpawned = true;
        }

        if (GameObject.Find("platform2").GetComponent<CalendarPuzzleController>().isTeleported && !niceWordsSpawned)
        {
			Debug.Log("despawning mean words...");
			foreach (GameObject i in niceWordList)
			{
				i.SetActive(true);
			}
			foreach (GameObject i in meanWordList)
			{
                if (i != null)
                {
					i.SetActive(false);
				}
				
			}
			niceWordsSpawned = true;

		}
    }
}
