using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

    public void DrowningCPR()
    {
        SceneManager.LoadScene("DrowningCPR");
    }

    //public void Snake()
    //{
    //    SceneManager.LoadScene("Snake");
    //}

    //public void PreviousScene()
    //{
    //    SceneManager.LoadScene("ModeSelect");
    //}

   
    //private void Update()
    //{
    //    if (OVRInput.GetDown(OVRInput.Button.Back))  
    //    {
    //        Application.Quit();
    //    }
    //}
}
