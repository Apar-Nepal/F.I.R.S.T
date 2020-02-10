using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FirstaidInstruction : MonoBehaviour
{
    #region HumanModel
    public GameObject responderModel;
    public GameObject responderPant;
    public GameObject victimModel;
    public GameObject chestAnchor;
    public GameObject drowningModel;
    #endregion

    #region Instruction
    public TextMeshPro instructionText;

    public GameObject callEmergencyNumber;
    #endregion

    public SoundManager soundManager;

    public GameObject animationController;

    public GameObject pointer;

    void Start()
    {
        responderModel.GetComponent<SkinnedMeshRenderer>().enabled = false;
        responderPant.GetComponent<SkinnedMeshRenderer>().enabled = false;
        victimModel.GetComponent<SkinnedMeshRenderer>().enabled = false;
        chestAnchor.GetComponent<CapsuleCollider>().enabled = false;
        drowningModel.SetActive(true);

        callEmergencyNumber.SetActive(false);

        //start coroutine
        StartCoroutine(WaitForDrowning());
    }

    IEnumerator WaitForDrowning()
    {
        yield return new WaitForSeconds(5f);

        Destroy(drowningModel.gameObject);

        responderModel.GetComponent<SkinnedMeshRenderer>().enabled = true;
        responderPant.GetComponent<SkinnedMeshRenderer>().enabled = true;
        victimModel.GetComponent<SkinnedMeshRenderer>().enabled = true;

        if (PlayerPrefs.GetInt("currentLang") == 0)
        {
            instructionText.text = "PDa'n]G;nfO{ af]npg !!@ df sn ug{'xf];";
        }
        else
        {
            instructionText.text = "Call emergency on 112 for ambulance";
        }
        callEmergencyNumber.SetActive(true);
        pointer.SetActive(true);

    }

    public void CallEmergencyNumber()
    {
        if (PlayerPrefs.GetInt("currentLang") == 0)
        {
            instructionText.text = "cfsl:ds gDa/df sn ul/b}";
        }
        else
            instructionText.text = "Calling Emergency number";
        StartCoroutine(CheckHeartbeat());
        callEmergencyNumber.SetActive(false);
        soundManager.CheckHeartBeatAudio();

        chestAnchor.GetComponent<CapsuleCollider>().enabled = true;
    }

    IEnumerator CheckHeartbeat()
    {
        yield return new WaitForSeconds(3);
        if (PlayerPrefs.GetInt("currentLang") == 0)
        {
            instructionText.text = "d'6'sf] w8sg hfFr ug{sf] nfuL 5ftLdf lyRg'xf];. olb ;LkLcf/ cfjZos k/]df,  tkfO{+sf] xft la/fdLsf] 5ftL dfly tn b]vfO{Psf] kf/fn] /Vg'xf];";
        }
        else
            instructionText.text = ("press on chest to check heartbeat. If CPR is needed get ready for CPR by clasping hand over chest area as shown.");

        
        animationController.GetComponent<AnimationController>().EnableChestAnchor();

        chestAnchor.GetComponent<CapsuleCollider>().enabled = true;
    }
}
