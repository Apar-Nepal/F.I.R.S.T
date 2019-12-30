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

    public void ModeSelect()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    public void Snake()
    {
        SceneManager.LoadScene("Snake");
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    public void UITest()
    {
        SceneManager.LoadScene("UIPointerTest");
    }

    public void PhysicalTest()
    {
        SceneManager.LoadScene("PhysicalPointerTest");
    }
}
