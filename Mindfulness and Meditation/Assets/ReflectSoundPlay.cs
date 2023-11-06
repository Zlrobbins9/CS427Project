using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectSoundPlay : MonoBehaviour
{
    bool audioPlayed = false;
    public AudioClip mySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (!audioPlayed && GameObject.Find("Main Camera").transform.position.z >= 25 && GameObject.Find("platform1").GetComponent<CalendarPuzzleController>().isTeleported)//todo: add condition) //collision occured
        {
            Debug.Log("audio played!!");
            GetComponent<AudioSource>().PlayOneShot(mySound);
            audioPlayed = true;
        }
    }
}
