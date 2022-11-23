using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingWeapon : MonoBehaviour
{

	public GameObject panel;


    // Update is called once per frame
    void Update()
    {
        if (panel != null) {
        	Time.timeScale = 0;
        }
    }
}
