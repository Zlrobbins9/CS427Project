using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instuct1 : MonoBehaviour
{
   public AudioClip mySound;
   private bool isOpen = false;

    void Start()
    {
     
    }
void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag =="Player" && !isOpen) //collision occured
		{
			GetComponent<AudioSource> ().PlayOneShot (mySound);
			isOpen = true;
		}
	}   
    // Update is called once per frame
    void Update()
    {
        
    }
}