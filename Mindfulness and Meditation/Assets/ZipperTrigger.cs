using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperTrigger : MonoBehaviour
{
   public AudioClip mySound;
void OnTriggerEnter (Collider other)
	{
	if(other.gameObject.tag =="Wand")
		{
				GetComponent<AudioSource> ().PlayOneShot (mySound);
		}
	}
}
