using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject checkPulseButton;
    public GameObject placeHandButton;
    public GameObject cprButton;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    private void Awake()
    {
        startCPRBtn = false;
        FirstPress = true;
        currentStepNum = 1;

        checkPulseButton.SetActive(false);
        placeHandButton.SetActive(false);
        cprButton.SetActive(false);
        option1.SetActive(true);
        option2.SetActive(true);
        option3.SetActive(true);
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

    void TurnOnOptions()
    {
        option1.SetActive(true);
        option2.SetActive(true);
        option3.SetActive(true);
    }

    void TurnOffOptions()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
    }

    public void QuizCorrect()
    {
        // check step num
        if (currentStepNum == 1)
        {
            // first quiz
            TurnOffOptions();

            // turn on button to check pulse
            checkPulseButton.SetActive(true);

            // check pulse

            currentStepNum++;
        }
        else if (currentStepNum == 2)
        {
            TurnOffOptions();

            // turn on the button to place hand over the chest
            placeHandButton.SetActive(true);

            currentStepNum++;
        }
        else
        {
            TurnOffOptions();

            // turn on CPRButton
            cprButton.SetActive(true);
        }
    }

    public void CheckPulse()
    {
        // trigger the animation of checking pulse
        handSimulationAnimator.SetTrigger("Check");
        TurnOnOptions();

        // distroy this button
        Destroy(checkPulseButton.gameObject);
    }

    public void PlaceHandOverChest()
    {
        // trigger animation of hand placing over the chest
        handSimulationAnimator.SetTrigger("Chest");
        TurnOnOptions();

        // distroy this game object
        Destroy(placeHandButton.gameObject);
    }

    public void QuizIncorrect()
    {
        // disable buttons of the quiz
        TurnOffOptions();

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
