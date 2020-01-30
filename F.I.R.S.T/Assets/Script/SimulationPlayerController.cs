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

        // only activate on first compresssion
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
        if (currentStepNum == 1)
        {
            // first quiz

            // turn on button to check pulse

            // check pulse

            currentStepNum++;
        }
        else if (currentStepNum == 2)
        {
            // turn on the button to place hand over the chest

            currentStepNum++;
        }
        else
        {
            // turn on CPRButton
        }
    }

    public void CheckPulse()
    {
        // trigger the animation of checking pulse

        // distroy this button
    }

    public void PlaceHandOverChest()
    {
        // trigger animation of hand placing over the chest

        // distroy this game object
    }

    public void QuizIncorrect()
    {
        // disable buttons of the quiz

        // activate button to try again

        // activate wrong option
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
