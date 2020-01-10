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
    public GameObject headAnchor;
    public bool headAnchorbool = false;
    public GameObject chestAnchor;
    public bool chestAnchorBool = false;

    public TextMeshPro instructionText;

    private void Start()
    {
        responderAnim = responder.GetComponent<Animator>();
        victimAnim = victim.GetComponent<Animator>();

        heartBeatMeter.SetActive(false);
        backButton.SetActive(false);

        counter = 0;

        // only head clickable initially
        chestAnchor.GetComponent<Button>().enabled = true;
        // headAnchor.GetComponent<Button>().enabled = true;
        headAnchorbool = true;
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
            responderAnim.SetTrigger("checkBreathing");

            counter = 1;

            // disable click action on head
            headAnchor.GetComponent<Button>().enabled = false;

            heartBeatMeter.SetActive(true);

            // start couroutine
            StartCoroutine(WaitForResuscitation());
        }
    }

    //IEnumerator WaitFOrHeadAnimation()
    //{
    //    yield return new WaitForSeconds(9);
    //    instructionText.text = "Start mouth to mouth Resuscitation ";
    //    StartCoroutine(WaitForResuscitation());
    //}

    IEnumerator WaitForResuscitation()
    {
        yield return new WaitForSeconds(3);
        instructionText.text = "Click on chest to start CPR";
        chestAnchor.GetComponent<Button>().enabled = true;
        chestAnchorBool = true;
        headAnchorbool = false;
    }
    #endregion


    #region CPR
    public void StartCPR ()
    {
        responderAnim.SetTrigger("chestPressure");
        victimAnim.SetTrigger("chestPressure");


        StartCoroutine(StopCpr());
    }
    #endregion

    IEnumerator StopCpr()
    {
        // stops the cpr
        yield return new WaitForSeconds(30);

        responderAnim.SetTrigger("stop");
        victimAnim.SetTrigger("stop");

        backButton.SetActive(true);
        instructionText.text = "Congratulation! You have successfully completed the training and can save people.";
    }
}
