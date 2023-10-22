using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPuzzleController : MonoBehaviour
{
    // Start is called before the first frame update
    string p1Str = "N/A";
    string p2Str = "N/A";
    string p3Str = "N/A";
    public string gameState = "playing";

    void Start()
    {
        //platform1
    }

    // Update is called once per frame
    void Update()
    {
        if (p1Str.Equals("N/A"))
        {  
            p1Str = GameObject.Find("platform1").GetComponent<WordFloor>().ReturnPhrase();
        }
        if (p2Str.Equals("N/A"))
        {
            p2Str = GameObject.Find("platform2").GetComponent<WordFloor>().ReturnPhrase(); //this script exists inside platform 2
        }
        if (p3Str.Equals("N/A"))
        {
            p3Str = GameObject.Find("platform3").GetComponent<WordFloor>().ReturnPhrase();
        }

        if (!p1Str.Equals("N/A") && !p2Str.Equals("N/A") && !p3Str.Equals("N/A")) //All three platforms have words on them
        {
            Debug.Log("all 3 platforms have values");
            int workValue = 0;
            if (p1Str.Contains("Studying")) // First word
            {
                workValue++;
            }
            if (p2Str.Contains("Studying")) // First word
            {
                workValue++;
            }
            if (p3Str.Contains("Studying")) // First word
            {
                workValue++;
            }
            Debug.Log(workValue);
            if (workValue == 2)
            {
                Debug.Log("you did it!");
            }else if (workValue == 1)
            {
                Debug.Log("You didnt do enough work");
            }
            else if (workValue == 0)
            {
                Debug.Log("You didnt do any work :(");
            }
            else if (workValue == 3)
            {
                Debug.Log("You pushed yourself too hard and burnt out before finishing.");
            }
            else
            {
                Debug.Log("ERROR: recieving impossible value as a result of the floor puzzle. Impossible value:" + workValue);
            }
        }
        else
        {
            Debug.Log(p1Str + " " + p2Str+ " " + " " +p3Str);
        }
    }
}
