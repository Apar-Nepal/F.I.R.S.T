using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AnimationController : MonoBehaviour
{

    // GameObjects that contains the animators
    public GameObject responder;
    public GameObject victim;
    public GameObject heartBeatMeter;
    public GameObject backButton;

    // Button Click counter
    int counter;

    // animators
    Animator responderAnim;
    Animator victimAnim;
    
    // Colliders
    public GameObject chestAnchor;

    public TextMeshPro instructionText;

    // Sound Manager
    public SoundManager soundManager;

    private void Start()
    {
        responderAnim = responder.GetComponent<Animator>();
        victimAnim = victim.GetComponent<Animator>();

        heartBeatMeter.SetActive(false);
        backButton.SetActive(false);

        counter = 0;

        chestAnchor.GetComponent<Button>().enabled = false;

    }


    #region CHeckBreathing
    public void CheckBreathing ()
    {
        if(counter == 1)
        {
            StartCPR();
            counter = 2;
        }

        if (counter == 0)
        {
            soundManager.CheckHeartBeatAudioTwo();

            responderAnim.SetTrigger("checkBreathing");

            counter = 1;

            DisableChestAnchor();

            heartBeatMeter.SetActive(true);

            // start couroutine
            StartCoroutine(WaitForResuscitation());
        }
    }

    public void DisableChestAnchor()
    {
        chestAnchor.GetComponent<SpriteRenderer>().enabled = false;
        chestAnchor.GetComponent<Button>().enabled = false;
    }

    IEnumerator WaitForResuscitation()
    {
        yield return new WaitForSeconds(3);
        instructionText.text = "Click on chest to start CPR";
        EnableChestAnchor();
    }
    #endregion

    public void EnableChestAnchor()
    {
        chestAnchor.GetComponent<SpriteRenderer>().enabled = true;
        chestAnchor.GetComponent<Button>().enabled = true;
    }

    #region CPR
    public void StartCPR ()
    {
        responderAnim.SetTrigger("chestPressure");
        victimAnim.SetTrigger("chestPressure");

        soundManager.StartCPRAudio();

        StartCoroutine(StopCpr());
    }
    #endregion

    IEnumerator StopCpr()
    {
        // stops the cpr
        yield return new WaitForSeconds(10);

        responderAnim.SetTrigger("stop");
        victimAnim.SetTrigger("stop");

        backButton.SetActive(true);
        instructionText.text = "Congratulation! You have successfully completed the training and can save people.";
    }
}
