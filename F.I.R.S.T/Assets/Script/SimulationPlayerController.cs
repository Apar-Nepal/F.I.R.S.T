using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationPlayerController : MonoBehaviour
{
    bool startCPRBtn;
    bool FirstPress;

    int numOfChestCompresssion;
    int totalChestCompression;
    float firstPressTime;

    private void Awake()
    {
        startCPRBtn = false;
        FirstPress = true;
    }

    private void Update()
    {

        // check total number of compression
        if ((Time.time - firstPressTime) == 18f)
        {
            if (totalChestCompression > 35 || totalChestCompression < 25)
            {
                Debug.Log("Failed");
            }
            else if (totalChestCompression > 33 || totalChestCompression < 27)
            {
                Debug.Log("1 star");
            }
            else if (totalChestCompression > 31 || totalChestCompression < 29)
            {
                Debug.Log("2 star");
            }
            else
            {
                Debug.Log("3 star");
            }
        }
    }

    // chest function
    public void ChestPress()
    {

        // only activate on first compresssion
        if (FirstPress)
        {
            startCPRBtn = true;
            firstPressTime = Time.time;
        }
        FirstPress = false;

        numOfChestCompresssion++;
        totalChestCompression++;
        if (startCPRBtn)
        {
            startCPRBtn = false;
            StartCoroutine(CheckEveryThreeSec());
        }
    }

    IEnumerator CheckEveryThreeSec()
    {
        yield return new WaitForSeconds(3);
        startCPRBtn = true;
        Debug.Log("check every 3 sec");
        numOfChestCompresssion = 0;
        if (numOfChestCompresssion < 5)
        {
            Debug.Log("too slow");
        }
        else if (numOfChestCompresssion>5)
        {
            Debug.Log("Too Fast");
        }
        else
        {
            Debug.Log("perfect");
        }
    }

    void CheckCompressionRate()
    {

    }
}
