using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimulationPlayerController : MonoBehaviour
{
    bool startCPRBtn;
    bool FirstPress;
    bool testCPR = true;
    bool startGameBool = false;

    int numOfChestCompresssion;
    int totalChestCompression;
    int currentStepNum;
    int waitTime;
    int startingIn;
    float firstPressTime;
    string quizQuestion;

    public Animator handSimulationAnimator;
    public Animator victimSimulationAnimator;

    public GameObject checkPulseButton;
    public GameObject placeHandButton;
    public GameObject cprTestButton;
    public GameObject cprGameButton;
    public GameObject firstQuiz;
    public GameObject secondQuiz;
    public GameObject thirdQuiz;
    public GameObject forthQuiz;
    public GameObject startGameButton;

    public TextMeshProUGUI questionText;

    private void Awake()
    {
        startCPRBtn = false;
        FirstPress = true;
        currentStepNum = 1;

        checkPulseButton.SetActive(false);
        placeHandButton.SetActive(false);
        cprTestButton.SetActive(false);
        firstQuiz.SetActive(true);
        secondQuiz.SetActive(false);
        thirdQuiz.SetActive(false);
        forthQuiz.SetActive(false);
        startGameButton.SetActive(false);
        cprGameButton.SetActive(false);

        questionText.text = "What Should be the first step when the victim is unresponsive?";
    }

    private void Update()
    {

        // check total number of compression
        if (((int)(Time.time - firstPressTime) == 9) && startCPRBtn)
        {
            if (totalChestCompression > 35 || totalChestCompression < 25)
            {
                questionText.text= "Failed";
            }
            else if (totalChestCompression > 33 || totalChestCompression < 27)
            {
                Debug.Log("1 star");
                questionText.text = "1 star";
            }
            else if (totalChestCompression > 31 || totalChestCompression < 29)
            {
                questionText.text = "2 star";
            }
            else
            {
                questionText.text = "3 star";
            }
        }

        if (startGameBool)
        {
            if ((startingIn - (int)Time.time) > 0)
            {
                questionText.text = "" + (startingIn - (int)Time.time);
            }
            
        }
    }

    // chest function
 

    public void QuizCorrect()
    {
        // check step num
        if (currentStepNum == 1)
        {
            // turn on button to check pulse
            checkPulseButton.SetActive(true);

            // check pulse text
            questionText.text = "Press on the button to check the pulse of the victim";

            currentStepNum++;

            // first quiz
            Destroy(firstQuiz.gameObject);
        }
        else if (currentStepNum == 2)
        {
            // place hand over the chest text
            questionText.text = "Press on the button to place hand on chest";

            // turn on the button to place hand over the chest
            placeHandButton.SetActive(true);

            currentStepNum++;

            // destroy quiz buttons
            Destroy(secondQuiz.gameObject);
        }
        else if(currentStepNum == 3)
        {
            questionText.text = "what should be the depth of chest compression";

            currentStepNum++;

            forthQuiz.SetActive(true);

            Destroy(thirdQuiz.gameObject);
        }
        else
        {
            quizQuestion = "Pressing on button gives one compression to victim. Press button on correct interval to do chest compression";

            questionText.text = quizQuestion;

            currentStepNum++;

            StartCoroutine(WaitForAnimation(cprTestButton, quizQuestion, 1));

            Destroy(forthQuiz.gameObject);
        }
    }

    public void CheckPulse()
    {
        // trigger the animation of checking pulse
        handSimulationAnimator.SetTrigger("Check");

        // distroy this button
        Destroy(checkPulseButton.gameObject);

        quizQuestion = "What should be the hand position for the Adult??";
        StartCoroutine(WaitForAnimation(secondQuiz, quizQuestion, 1));
    }

    public void PlaceHandOverChest()
    {
        // trigger animation of hand placing over the chest
        handSimulationAnimator.SetTrigger("Chest");

        // distroy this game object
        Destroy(placeHandButton.gameObject);

        quizQuestion = "What sould be the compression rate for the cpr?";
        StartCoroutine(WaitForAnimation(thirdQuiz, quizQuestion, 2));
    }

    public void TestChestCompression()
    {
        if (testCPR)
        {
            handSimulationAnimator.SetTrigger("Compress");
            victimSimulationAnimator.SetTrigger("Compress");
        }

        if (currentStepNum == 5)
        {
            quizQuestion = "Press Start Button when ready to start the game";

            StartCoroutine(WaitForAnimation(startGameButton, quizQuestion, 4));

            currentStepNum++;
        }
    }

    public void StartGame()
    {
        quizQuestion = "GO!!!";

        startGameBool = true;
        startingIn = (int)Time.time + 3;

        StartCoroutine(WaitForAnimation(cprGameButton, quizQuestion, 4));

        Destroy(cprTestButton.gameObject);
        //Destroy(startGameButton.gameObject);
    }

    // Actual game for chest compression
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

    IEnumerator WaitForAnimation(GameObject quizNo, string quizQuestion, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        quizNo.SetActive(true);
        questionText.text = quizQuestion;
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
}
