using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Dropdown dropdown;

    private void Start()
    {
        dropdown.value = PlayerPrefs.GetInt("currentLang");
    }

    public void languagedropdown(int langindex)
    {
        PlayerPrefs.SetInt("currentLang", dropdown.value);
    }
}
