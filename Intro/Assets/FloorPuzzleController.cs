using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPuzzleController : MonoBehaviour
{
    // Start is called before the first frame update
    string p1Str = "N/A";
    string p2Str = "N/A";
    string p3Str = "N/A";
    string gameState = "Playing";
    bool isReset = false;
    int timer = 0;
    string[] stringList = { "Play video games", "Eat dinner", "Take a phone break", "Studying (1)", "Studying (2)", "Studying (3)" };
    GameObject[] objList= new GameObject[6];
    void Start()
    {
        for(int i = 0; i < 6; i++)
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
                Debug.Log(workValue);
                if (workValue == 2)
                {
                    Debug.Log("you did it!");
                    gameState = "Won";
                }
                else if (workValue == 1)
                {
                    Debug.Log("You didnt do enough work");
                    gameState = "Lost - 1";
                }
                else if (workValue == 0)
                {
                    Debug.Log("You didnt do any work :(");
                    gameState = "Lost - 0";
                }
                else if (workValue == 3)
                {
                    Debug.Log("You pushed yourself too hard and burnt out before finishing.");
                    gameState = "Lost - 3";
                }
                else
                {
                    Debug.Log("ERROR: recieving impossible value as a result of the floor puzzle. Impossible value:" + workValue);
                }

                if (isReset == false)
                {
                    Debug.Log("resetting letters... gameState is " + gameState);
                    RemoveUnusdLettrs();
                    isReset = true;

                }
            }
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
        }
        else if(gameState.Contains("Lost")) //lose screen
        {
            GameEnd();
        }
    }

    void GameEnd()
    {
        Debug.Log("Game Over, end state is " + gameState);
        if (gameState.Contains("Lost") && Input.GetKeyDown("v")) //game is lost, offer option to reset (win does not get to)
        {
            Debug.Log("beginning reset...");
            //disable the three 
            GameObject.Find(p1Str).SetActive(false);
            GameObject.Find(p2Str).SetActive(false);
            GameObject.Find(p3Str).SetActive(false);

            // by this point, all words should be disabled

            foreach (GameObject i in objList)
            {
                i.SetActive(true);
            }
            
            Debug.Log("before reset, p1str is " + p1Str);

            p1Str = "N/A";
            p2Str = "N/A";
            p3Str = "N/A";
            timer = 1;
            gameState = "Playing";
            isReset = false;
            Debug.Log("after reset, p1str is " + p1Str);
        }
    }

    void RemoveUnusdLettrs()
    {
        Debug.Log("RemoveUnusedLetters is running...");
        if (!isReset)
        {
            Debug.Log("RemoveUnusedLetters is running with isReset as false...");
            foreach (GameObject i in objList)
            {
                if (i.GetComponent<GrabbableObject>().enabled) //if this is true, the word has not had its Grabbable object removed
                {
                    i.SetActive(false); //disable the word for now
                }
            }
        }
        
    }

    public bool HasLost()
    {
        if (gameState.Contains("Lost"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
