using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManager : MonoBehaviour
{
    
    public void Home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }

    public void ModeSelect()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ModeSelect");
    }

    public void Snake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Snake");
    }

    public void PreviousScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ModeSelect");
    }
}
