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

    public void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
