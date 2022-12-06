using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullettimeTimer : MonoBehaviour
{
    public Slider slider;
    public float gameTime;

    private bool stopTimer = false;


    void Start()
    {
        slider.maxValue = 1.0f;
        slider.value = 1.0f;
    }

    public void SetMaxTime(float maxTime)
    {
        slider.maxValue = maxTime;
    }
    public void SetRemainingTime(float remainingTime)
    { 
            slider.value = remainingTime;
         
    }
    public void ResetTimer()
    {
        slider.maxValue = 1.0f;
        slider.value = 1.0f;
        stopTimer = false;
    }
}
