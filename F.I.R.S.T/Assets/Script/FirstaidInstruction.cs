using System.Collections;
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
    #endregion

    void Start()
    {
        responderModel.GetComponent<SkinnedMeshRenderer>().enabled = false;
        responderPants.GetComponent<SkinnedMeshRenderer>().enabled = false;
        responderTshirt.GetComponent<SkinnedMeshRenderer>().enabled = false;
        victimModel.GetComponent<SkinnedMeshRenderer>().enabled = false;

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

        instructionText.text = "click on head to check heartrate of the patient";
    }
}
