using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationPlayerController : MonoBehaviour
{
    //public GameObject chestAnchor;
    //public Animator handAnimator;
    //public Animator victimAnimator;

    float compressionRate;
    float nextCompression;
    float previousCompression;

    private void Update()
    {
        nextCompression = previousCompression + .6f;
    }

    // chest function
    public void ChestPress()
    {
        // handAnimator.SetTrigger("handAnim");
        // victimAnimator.SetTrigger("victimAnim");

        previousCompression = Time.time;
        Debug.Log(previousCompression - nextCompression);
        //Debug.Log(previousCompression + "  " + nextCompression);

        if ((previousCompression - nextCompression) > 0.1 || (previousCompression - nextCompression) < -0.1)
        {
            Debug.Log("late");
        }
        else
            Debug.Log("combo");
            
    }
}
