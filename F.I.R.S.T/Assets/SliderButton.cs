using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderButton : MonoBehaviour
{
    public Scrollbar sliderValue;
   

    private void Awake()
    {
        sliderValue = this.GetComponent<Scrollbar>();
    }

    public void ButtonLeft()
    {
        sliderValue.value = sliderValue.value - (float)0.50;
    }

    public void ButtonRight()
    {
        sliderValue.value = sliderValue.value + (float)0.50;
    }
}
