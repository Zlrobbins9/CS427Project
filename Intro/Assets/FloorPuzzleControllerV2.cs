using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPuzzleControllerV2 : MonoBehaviour
{
    string p1Str = "N/A";
    string p2Str = "N/A";
    string p3Str = "N/A";
    string gameState = "Playing";
    bool isReset = false;
    string[] stringList = { "Play video games", "Eat dinner", "Take a phone break", "Studying (1)", "Studying (2)", "Studying (3)" };
    GameObject[] objList = new GameObject[6];
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            objList[i] = GameObject.Find(stringList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.Equals("Playing"))
        {
            if (!p1Str.Equals("N/A") && !p2Str.Equals("N/A") && !p3Str.Equals("N/A")) //All three platforms have words on them
            {
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
                Debug.Log("workValue is " + workValue);

                if (workValue == 0)
                {
                    Debug.Log("You didnt do any work :(");
                    gameState = "Lost - 0";
                }
                else if (workValue == 1)
                {
                    Debug.Log("You didnt do enough work");
                    gameState = "Lost - 1";
                }
                else if (workValue == 2)
                {
                    Debug.Log("you did it!");
                    gameState = "Won";
                }
                else if (workValue == 3)
                {
                    Debug.Log("You pushed yourself too hard and burnt out before finishing.");
                    gameState = "Lost - 3";
                }
                else
                {
                    Debug.Log("ERROR: recieving impossible value as a result of the floor puzzle. Impossible value:" + workValue);
                    gameState = "Error";
                }

                //gameState = "Game Over";
            }
        }
        else
        {
            if (gameState.Contains("Lost") )
            {
                Debug.Log("this project makes me wanna die");
            }
        }
    }
}
