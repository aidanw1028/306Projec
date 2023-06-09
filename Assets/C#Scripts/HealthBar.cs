using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Slider slider;

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void SetMaxHP(float hp) {
   		slider.maxValue = hp;
   		slider.value = hp;
   	}

   	// call this function to update sliders hp according to actual players hp
   	public void SetHealth(float hp) {
   		slider.value -= hp;
   	}

	public void addHealth(float hp){
		slider.value += hp;
	}
}