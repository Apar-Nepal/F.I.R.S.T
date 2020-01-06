using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpingAnime : MonoBehaviour
{
    public Animator anim;

    public void AnimatePumping()
    {
        anim.SetTrigger("pumping");
    }
}
