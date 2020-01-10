﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FirstaidInstruction : MonoBehaviour
{
    #region HumanModel
    public GameObject responderTshirt;
    public GameObject responderModel;
    public GameObject responderPants;

    public GameObject victimModel;
    #endregion

    #region Instruction
    public TextMeshPro instructionText;
    public GameObject drowningImage;
    public GameObject m_CPRHandPostion;
    #endregion

    void Start()
    {
        responderModel.GetComponent<SkinnedMeshRenderer>().enabled = false;
        responderPants.GetComponent<SkinnedMeshRenderer>().enabled = false;
        responderTshirt.GetComponent<SkinnedMeshRenderer>().enabled = false;
        victimModel.GetComponent<SkinnedMeshRenderer>().enabled = false;

        m_CPRHandPostion.GetComponent<Image>().enabled = false;

        //start coroutine
        StartCoroutine(DrowningImage());
    }

    IEnumerator DrowningImage()
    {
        yield return new WaitForSeconds(3);
        
        drowningImage.GetComponent<Image>().enabled = false;
        responderModel.GetComponent<SkinnedMeshRenderer>().enabled = true;
        responderPants.GetComponent<SkinnedMeshRenderer>().enabled = true;
        responderTshirt.GetComponent<SkinnedMeshRenderer>().enabled = true;
        victimModel.GetComponent<SkinnedMeshRenderer>().enabled = true;

        instructionText.text = "Call emergency on 112 for ambulance";
        StartCoroutine(CheckHeartbeat());
    }

    IEnumerator CheckHeartbeat()
    {
        yield return new WaitForSeconds(3);
        instructionText.text = ("press/trigger on chest to check to check heartbeat. If CPR is needed get ready for CPR by clasping hand over chest area as shown.");

        // display image for CPR hand postion
        m_CPRHandPostion.GetComponent<Image>().enabled = true;
    }
}
