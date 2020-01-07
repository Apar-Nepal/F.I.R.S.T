using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        // check breathing for the victim
        if (collision.collider.tag == "victimHead")
        {
            anim.SetTrigger("checkBreathing");
        }

        // start CPR
        if (collision.collider.tag == "victimChest")
        {
            anim.SetTrigger("pumping");
        }
    }
}
