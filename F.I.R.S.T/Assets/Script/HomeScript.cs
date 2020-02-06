using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    // Home Panel
    public GameObject homePannel;
    public GameObject infoPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        infoPanel.SetActive(false);
    }

    // Info button interaction
    public void InfoActive()
    {
        homePannel.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void HomeActive()
    {
        infoPanel.SetActive(false);
        homePannel.SetActive(true);
    }
}
