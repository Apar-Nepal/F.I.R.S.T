using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AnimationController : MonoBehaviour
{

    // GameObjects that contains the animators
    public GameObject responder;
    public GameObject victim;
    public GameObject heartBeatMeter;
    public GameObject backButton;
    public GameObject handPositionCPR;
    public GameObject ambulance;

    // Button Click counter
    int counter;

    // 0 for Nepali and 1 for english Language Index
    int langIndex;

    // Fonts
    public TMP_FontAsset nepali;
    public TMP_FontAsset english;

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

        langIndex = PlayerPrefs.GetInt("currentLang");

        DisableChestAnchor();

        handPositionCPR.SetActive(false);
        if (langIndex == 0)
        {
            instructionText.GetComponent<TextMeshPro>().font = nepali;
        }
        else
        {
            instructionText.GetComponent<TextMeshPro>().font = english;
        }

        ambulance.SetActive(false);
    }


    public void CheckBreathing()
    {
        if (counter == 1)
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

            // start couroutine
            StartCoroutine(WaitForResuscitation());

            handPositionCPR.SetActive(true);
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
        if (langIndex == 0)
        {
            instructionText.text = "l;lkcf ;'? ug{sf nflu 5ftLdf lyRg'xf]";
        }
        else
        {
            instructionText.text = "Click on chest to start CPR";
        }
    }


    IEnumerator PositionHands()
    {
        yield return new WaitForSeconds(8);
        EnableChestAnchor();

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

    public void StartCPR()
    {
        responderAnim.SetTrigger("chestPressure");
        victimAnim.SetTrigger("chestPressure");

        StartCoroutine(StopCpr());
    }

    IEnumerator StopCpr()
    {
        // stops the cpr
        yield return new WaitForSeconds(15);

        soundManager.AmbulanceSound();

        responderAnim.SetTrigger("stop");
        victimAnim.SetTrigger("stop");

        handPositionCPR.SetActive(false);

        ambulance.SetActive(true);

        backButton.SetActive(true);
        if (langIndex == 0)
        {
            instructionText.text = "awfO{ 5, tkfO{+n] k|lzIf0f k'/f ug{' ePsf] 5.";
        }
        else
            instructionText.text = "Congratulation! You have successfully completed the training and can save people.";
    }
}
