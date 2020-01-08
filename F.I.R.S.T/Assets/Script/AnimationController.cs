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


        // only head clickable initially
        chestAnchor.GetComponent<Button>().enabled = false;
        headAnchor.GetComponent<Button>().enabled = true;
        headAnchorbool = true;
    }


    #region CHeckBreathing
    public void CheckBreathing ()
    {
        responderAnim.SetTrigger("checkBreathing");

        // disable click action on head
        headAnchor.GetComponent<Button>().enabled = false;

        // start couroutine
        StartCoroutine(WaitFOrHeadAnimation());
    }

    IEnumerator WaitFOrHeadAnimation()
    {
        yield return new WaitForSeconds(9);
        instructionText.text = "Start mouth to mouth Resuscitation ";
        StartCoroutine(WaitForResuscitation());
    }

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
    }
    #endregion
}
