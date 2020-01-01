using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Navigator : MonoBehaviour
{
    public Scrollbar sliderValue;
    int scrollPage;

    public GameObject pageNoText;
    private TextMeshPro text;

    private void Awake()
    {
        text = pageNoText.GetComponent<TextMeshPro>();
        Debug.Log(text.text);
        text.text = 1 + "";
        scrollPage = 1;
    }

    public void ButtonLeft()
    {
        sliderValue.value = sliderValue.value - (float)0.50;
        // change page
        if (scrollPage > 1)
        {
            scrollPage--;
        }

        ChangePage();
    }

    public void ButtonRight()
    {
        sliderValue.value = sliderValue.value + (float)0.50;

        if (scrollPage<3)
        {
            scrollPage++;
        }

        // change page number
        ChangePage();
    }

    void ChangePage()
    {
        text.text = "" + scrollPage;
    }
}
