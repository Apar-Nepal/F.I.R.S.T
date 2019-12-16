using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

    public Text text;
    int counterText;
    public GameObject gameOverPannel;

    int totalTime;
    int minute;
    int second;
    int half;
    int endTimer;

    // Use this for initialization
    private void Start()
    {
        counterText = 60;
        gameOverPannel = GameObject.Find("GameOverPannel");
        half = 31;
        endTimer = 5;
        gameOverPannel.SetActive(false);
    }


    // Update is called once per frame
    void Update () {
        if (counterText > 0)
        {
            counterText = 60 - (int)Time.time;
        }
        

        minute = counterText / 60;
        second = counterText % 60;

        if (second < 10)
        {
            text.text = minute + " : 0" + second;
        }
        else
        {
            text.text = minute + " : " + second;
        }

        beep();
	}

    public void beep()
    {
        if (counterText == half)
        {
            EditorApplication.Beep();
        }
        if (counterText == endTimer && counterText != 0)
        {
             endTimer -= 1;
            EditorApplication.Beep();
        }
        else if (counterText == 0)
        {
            gameOverPannel.SetActive(true);
        }

    }
}
