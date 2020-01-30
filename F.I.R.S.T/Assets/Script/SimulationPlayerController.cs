using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationPlayerController : MonoBehaviour
{
    bool startCPRBtn;
    bool FirstPress;

    int numOfChestCompresssion;
    int totalChestCompression;
    int currentStepNum;
    float firstPressTime;

    public Animator handSimulationAnimator;
    public Animator victimSimulationAnimator;


    private void Awake()
    {
        startCPRBtn = false;
        FirstPress = true;
        currentStepNum = 1;
    }

    private void Update()
    {

        // check total number of compression
        if ((Time.time - firstPressTime) == 18f)
        {
            if (totalChestCompression > 35 || totalChestCompression < 25)
            {
                Debug.Log("Failed");
            }
            else if (totalChestCompression > 33 || totalChestCompression < 27)
            {
                Debug.Log("1 star");
            }
            else if (totalChestCompression > 31 || totalChestCompression < 29)
            {
                Debug.Log("2 star");
            }
            else
            {
                Debug.Log("3 star");
            }
        }
    }

    // chest function
    public void ChestPress()
    {

        // only activate on first compresssion 2.566   2.949
        if (FirstPress)
        {
            startCPRBtn = true;
            firstPressTime = Time.time;
        }
        FirstPress = false;

        numOfChestCompresssion++;
        totalChestCompression++;
        if (startCPRBtn)
        {
            startCPRBtn = false;
            StartCoroutine(CheckEveryThreeSec());
        }

        handSimulationAnimator.SetTrigger("Compress");
        victimSimulationAnimator.SetTrigger("chestPressure");

    }

    public void QuizCOrrect()
    {
        // check step num
            // First quiz

            // Second quiz

            // Third quiz
    }

    public void QuizIncorrect()
    {
        // try again.
    }

    IEnumerator CheckEveryThreeSec()
    {
        yield return new WaitForSeconds(3);
        startCPRBtn = true;
        Debug.Log("check every 3 sec");
        numOfChestCompresssion = 0;
        if (numOfChestCompresssion < 5)
        {
            Debug.Log("too slow");
        }
        else if (numOfChestCompresssion>5)
        {
            Debug.Log("Too Fast");
        }
        else
        {
            Debug.Log("perfect");
        }
    }

    void CheckCompressionRate()
    {

    }
}
