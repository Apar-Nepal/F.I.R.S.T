﻿using System.Collections;
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
    
    // Collider
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

        chestAnchor.GetComponent<CapsuleCollider>().enabled = false;

    }



    public void CheckBreathing ()
    {
        if(counter == 1)
        {
            soundManager.StartCPRAudio();
            StartCPR();
            counter = 2;
            DisableChestAnchor();
            heartBeatMeter.SetActive(false);
        }

        if (counter == 0)
        {
            soundManager.HeartBeat();

            responderAnim.SetTrigger("checkBreathing");

            counter = 1;

            DisableChestAnchor();

              // need to activate it later in listning part
            
            // start couroutine
            StartCoroutine(WaitForResuscitation());
        }
    }

    public void DisableChestAnchor()
    {
        chestAnchor.GetComponent<SpriteRenderer>().enabled = false;
        chestAnchor.GetComponent<CapsuleCollider>().enabled = false;
    }

    IEnumerator WaitForResuscitation()
    {
        yield return new WaitForSeconds(3);
        heartBeatMeter.SetActive(true);

        // play hearbeat audio
        soundManager.HeartBeat();

        // add 10 sec delay while playing the heart beat sound
        StartCoroutine(PositionHands());

        instructionText.text = "Click on chest to start CPR";
        EnableChestAnchor();
    }


    IEnumerator PositionHands()
    {
        yield return new WaitForSeconds(10);

        // change animation state and stop listining
        responderAnim.SetTrigger("Listening");
        soundManager.CheckHeartBeatAudioTwo();

        // stop looping sound and change pitch back to normal
        soundManager.source.loop = false;
        soundManager.source.pitch = 1;
    }

    public void EnableChestAnchor()
    {
        chestAnchor.GetComponent<SpriteRenderer>().enabled = true;
        chestAnchor.GetComponent<CapsuleCollider>().enabled = true;
    }

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
        yield return new WaitForSeconds(15);

        responderAnim.SetTrigger("stop");
        victimAnim.SetTrigger("stop");

        backButton.SetActive(true);
        instructionText.text = "Congratulation! You have successfully completed the training and can save people.";
    }
}
