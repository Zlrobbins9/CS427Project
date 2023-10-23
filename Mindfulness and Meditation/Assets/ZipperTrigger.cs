using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperTrigger : MonoBehaviour
{
   public AudioClip mySound;
void OnTriggerEnter (ZipperOpen other)
	{
	if(/*other.gameObject.tag =="Wand"*/Input.GetKey("z"))
		{
				GetComponent<AudioSource> ().PlayOneShot (mySound);
		}
	}
}
