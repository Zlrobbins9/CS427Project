using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarPuzzleController : MonoBehaviour
{
    // Start is called before the first frame update
    string p1Str = "N/A";
    string p2Str = "N/A";
    string p3Str = "N/A";
    string gameState = "Playing";
    public bool isTeleported = false;
    bool isReset = false;
    int loseVal = -5;
    public GameObject[] taskObjList;
    public GameObject[] goalObjList;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject i in goalObjList)
        {
            i.SetActive(false);
        }
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

                loseVal = workValue;

                if (isReset == false)
                {
                    Debug.Log("resetting letters... gameState is " + gameState);
                    RemoveUnusdLettrs();
                    isReset = true;

                }
            }
            if (p1Str.Equals("N/A"))
            {
                p1Str = GameObject.Find("platform1").GetComponent<WordPlatform>().ReturnPhrase();
            }
            if (p2Str.Equals("N/A"))
            {
                p2Str = GameObject.Find("platform2").GetComponent<WordPlatform>().ReturnPhrase(); //this script exists inside platform 2
            }
            if (p3Str.Equals("N/A"))
            {
                p3Str = GameObject.Find("platform3").GetComponent<WordPlatform>().ReturnPhrase();
            }
        }
        else if(gameState.Contains("Lost")) //lose screen
        {
            goalObjList[loseVal].SetActive(true);
            GameEnd();
        }else if (gameState.Equals("Won"))
        {
            goalObjList[loseVal].SetActive(true);

            if (!isTeleported)
            {
                GameObject.Find("CAVE2-PlayerController").transform.position = new Vector3(-3f, 0f, -25f);
                isTeleported = true;
            }
            
        }
    }

    void GameEnd()
    {
        Debug.Log("Game Over, end state is " + gameState);
        if (gameState.Contains("Lost") && (Input.GetKeyDown("v") || CAVE2.GetButtonDown(CAVE2.Button.ButtonUp))) //game is lost, offer option to reset (win does not get to)
        {
            Debug.Log("beginning reset...");
            //disable the three 
            GameObject.Find(p1Str).SetActive(false);
            GameObject.Find(p2Str).SetActive(false);
            GameObject.Find(p3Str).SetActive(false);

            // by this point, all words should be disabled

            foreach (GameObject i in taskObjList)
            {
                i.SetActive(true);
            }
            
            Debug.Log("before reset, p1str is " + p1Str);

            p1Str = "N/A";
            p2Str = "N/A";
            p3Str = "N/A";
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
            foreach (GameObject i in taskObjList)
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
