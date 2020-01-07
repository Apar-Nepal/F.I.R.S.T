using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject chestAnchor;

    private void Start()
    {
        responderAnim = responder.GetComponent<Animator>();
        victimAnim = victim.GetComponent<Animator>();


        // only head clickable initially
        chestAnchor.GetComponent<Button>().enabled = false;
        headAnchor.GetComponent<Button>().enabled = true;
    }

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
        chestAnchor.GetComponent<Button>().enabled = true;
    }

    public void StartCPR ()
    {
        responderAnim.SetTrigger("chestPressure");
        victimAnim.SetTrigger("chestPressure");
    }        
    
}
